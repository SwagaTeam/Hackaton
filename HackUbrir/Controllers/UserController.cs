using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}
