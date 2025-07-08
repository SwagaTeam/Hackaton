using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
public class TestController(ITestService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create()
    {
        try
        {
            return Ok(await service.Create());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}