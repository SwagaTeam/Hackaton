using Application.Dto;
using Application.Middleware;
using Application.Models.Roles;
using Application.Services.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class Auth : IAuth
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBlacklistService blacklistService;

        public Auth(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IBlacklistService blacklistService)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.blacklistService = blacklistService;
        }

        public int? GetCurrentUserId()
        {
            var claimsIdentity = httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            int id = int.Parse(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "-1");
            return id;
        }


        public List<string> GetCurrentUserRoles()
        {
            var claimsIdentity = httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            return claimsIdentity?.FindAll(ClaimTypes.Role).Select(claim => claim.Value).ToList() ?? new List<string>();
        }

        public string GenerateJwtToken(UserModel user)
        {
            Console.WriteLine($"Generating token for user: {user.Id}");
            var userRoles = new List<string>();

            if (user.IsAdmin)
                userRoles.Add(UserRoles.ADMIN);
            else
                userRoles.Add(UserRoles.USER);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString() ?? "-1"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void Logout(string token)
        {
            blacklistService.AddTokenToBlacklist(token);
        }
    }
}
