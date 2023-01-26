using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;

namespace TestPlatform.WebAPI.Controllers;

[Authorize]
[Route("api/answerOptions")]
[ApiController]
public class AnswerOptionController : ControllerBase
{
    private readonly IAnswerOptionService _answerOptionService;

    public AnswerOptionController(IAnswerOptionService answerOptionService)
    {
        _answerOptionService = answerOptionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByQuestionId([FromQuery] int questionId)
    {
        IEnumerable<AnswerOptionDTO> answerOptions;

        try
        {
            answerOptions = await _answerOptionService.GetByQuestionId(questionId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(answerOptions);
    }
}
