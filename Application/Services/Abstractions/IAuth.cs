using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IAuth
    {
        public string GenerateJwtToken(UserEntity user);
        int? GetCurrentUserId();
        void Logout(string token);
        List<string> GetCurrentUserRoles();
    }
}
