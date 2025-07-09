using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class AiController(IApiService apiService) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<ActionResult<string>> GetShortDescription([FromBody] ShortDescriptionRequest request)
    {
        try
        {
            var result = await apiService.GetSummaryAsync(request.Content);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAnswerQuestions([FromBody] AiQueryRequest request)
    {
        try
        {
            var result = await apiService.AskQuestionAsync(request.Question, request.Text);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}