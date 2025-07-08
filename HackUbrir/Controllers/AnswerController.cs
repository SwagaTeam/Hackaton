using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
public class AnswerController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }
}