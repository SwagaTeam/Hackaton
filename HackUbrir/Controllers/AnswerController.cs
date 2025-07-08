using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class AnswerController(IAnswerService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AnswerDto dto)
    {
        try
        {
            var id = await service.Create(dto);
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get-by/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var answer = await service.GetById(id);
            return Ok(answer);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}