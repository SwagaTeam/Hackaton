using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelController(ILevelService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] LevelDtoRequest dtoRequest)
    {
        try
        {
            var id = await service.Create(dtoRequest);
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
            var level = await service.GetById(id);
            return Ok(level);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}