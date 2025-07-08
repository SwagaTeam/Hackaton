using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
public class QuestionController(IQuestionService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] QuestionRequest request)
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