using Application.Dto;
using Application.Services.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelController(ILevelService service, IAuth auth, IUserService userService) : ControllerBase
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

    [HttpGet("is-level-completed")]
    public async Task<IActionResult> IsLvlCompleted([FromQuery] int rightAnswers, int questionsCount, int lvlNumber)
    {
        try
        {
            int percent = rightAnswers / questionsCount;

            if(percent >= 0.8)
            {
                var id = auth.GetCurrentUserId();
                var entity = await userService.GetUser((int)id);

                if (entity.CurrentLevelNumber >= lvlNumber)
                    return Ok();
                entity.CurrentLevelNumber++;
                
                await userService.Update(entity);

                return Ok(true);
            }

            return Ok(false);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}