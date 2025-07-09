using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController(IModuleService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ModuleDtoRequest request)
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

    [HttpGet("get-by/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var module = await service.GetById(id);
            return Ok(module);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await service.GetAll());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}