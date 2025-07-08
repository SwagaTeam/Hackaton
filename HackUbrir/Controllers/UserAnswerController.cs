using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HackUbrir.Controllers;

[ApiController]
[Route("[controller]")]
public class UserAnswerController(IUserAnswerService service) : ControllerBase
{
    [HttpPost("get-correct-answers")]
    public async Task<IActionResult> GetCorrectSelectAnswers([FromBody] UserAnswerRequest request)
    {
        try
        {
            var result = await service.GetCorrectSelectAnswers(request);
            return Ok(result);
        }
        catch  (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}