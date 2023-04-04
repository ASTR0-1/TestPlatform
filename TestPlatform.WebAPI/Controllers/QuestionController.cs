using Microsoft.AspNetCore.Mvc;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;

namespace TestPlatform.WebAPI.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionController : ControllerBase
{
	private readonly IQuestionService _questionService;

	public QuestionController(IQuestionService questionService)
	{
		_questionService = questionService;
	}

	[HttpGet]
	public async Task<IActionResult> GetByTestId([FromQuery] int testId)
	{
		IEnumerable<QuestionDTO> questions = await _questionService.GetByTestId(testId);

		return Ok(questions);
	}
}
