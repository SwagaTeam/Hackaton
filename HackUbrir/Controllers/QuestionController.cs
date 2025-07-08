using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController(IQuestionService questionService, IAuth auth, IUserService userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] QuestionRequest request)
    {
        try
        {
            var id = await questionService.Create(request);
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
            var question = await questionService.GetById(id);
            return Ok(question);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get-cards")]
    public async Task<IActionResult> GetCards()
    {
        try
        {
            var currentUserId = auth.GetCurrentUserId();
            if (currentUserId is null or -1) return Unauthorized();
            var user = await userService.GetUser((int)currentUserId);
            var questions = await questionService.GetRandomQuestionsBelowLevel(user.CurrentLevelNumber);
            return Ok(questions);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}