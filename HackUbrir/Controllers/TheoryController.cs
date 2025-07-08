using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class TheoryController(ITheoryService service) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] TheoryDto dto)
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

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}