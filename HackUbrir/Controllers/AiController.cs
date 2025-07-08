using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;
[ApiController]
[Route("[controller]")]
public class AiController(IApiService apiService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<ActionResult<string>> GetShortDescription(string content)
    {
        try
        {
            var result = await apiService.GetSummaryAsync(content);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAnswerQuestions(string question, string content)
    {
        try
        {
            var result = await apiService.AskQuestionAsync(question, content);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}