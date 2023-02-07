using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;

namespace TestPlatform.WebAPI.Controllers;

[Authorize(Roles = "Administrator")]
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
        IEnumerable<AnswerOptionDTO> answerOptions = await _answerOptionService.GetByQuestionId(questionId);

        return Ok(answerOptions);
    }
}
