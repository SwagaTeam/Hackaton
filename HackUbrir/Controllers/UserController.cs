using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HackUbrir.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuth auth;
        private readonly IUserService userService;

        public UserController(IAuth auth, IEncrypt encrypt, IUserService userService)
        {
            this.auth = auth;
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginSubscriber([FromBody] LoginModel loginModel)
        {
            try
            {
                if (auth.GetCurrentUserId() != -1)
                    throw new Exception($"Вы уже авторизованы");
                var user = await userService.ValidateCredentials(loginModel.Login, loginModel.Password);
                if (user == null)
                    return Unauthorized("Неверный номер/пароль");
                var token = auth.GenerateJwtToken(user);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterSubscriber([FromBody] RegisterModel model)
        {
            try
            {
                var result = await userService.Create(model);
                if (result == null)
                    return BadRequest("Ошибка при регистрации пользователя");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var id = auth.GetCurrentUserId();
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Пустой токен.");
            }

            auth.Logout(token);
            return Ok("Успешный выход из системы.");
        }
    }
}
