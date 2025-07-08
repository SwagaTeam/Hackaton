using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuth auth;
        private readonly IEncrypt encrypt;

        public UserController(IAuth auth, IEncrypt encrypt)
        {
            this.auth = auth;
            this.encrypt = encrypt;
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}
