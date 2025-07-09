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
    public async Task<IActionResult> IsLvlCompleted([FromQuery] int rightAnswers, int questionsCount)
    {
        try
        {
            int percent = rightAnswers / questionsCount;

            if(percent >= 0.8)
            {
                var id = auth.GetCurrentUserId();
                var userModel = await userService.GetUser((int)id);

                var userEntity = new UserEntity() {
                  Id=userModel.Id,
                  IsAdmin = userModel.IsAdmin,
                  FullName = userModel.FullName,
                  Login = userModel.Login,
                  Password = userModel.Password,
                  Salt = userModel.Salt,
                  CurrentLevelNumber = userModel.CurrentLevelNumber++ 
                };
                await userService.Update(userEntity);

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