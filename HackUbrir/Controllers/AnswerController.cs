using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class AnswerController(IAnswerService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AnswerRequest request)
    {
        try
        {
            var id = await service.Create(request);
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}