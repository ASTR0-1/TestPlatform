using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;

namespace TestPlatform.WebAPI.Controllers;

[Authorize]
[Route("api/tests")]
[ApiController]
public class TestController : ControllerBase
{
	private readonly ITestService _testService;

	public TestController(ITestService testService)
	{
		_testService = testService;
	}

	[Authorize(Roles = "Administrator")]
	[HttpGet("{testId}")]
	public async Task<IActionResult> GetByTestId(int testId)
	{
		TestDTO test = await _testService.GetByTestId(testId);

		return Ok(test);
	}

	[HttpGet("{testId}/result")]
	public async Task<IActionResult> GetResult(int testId, [FromQuery] int[] answers)
	{
		int result = await _testService.GetResultAsync(testId, User.Identity.Name, answers);

		return Ok(result);
	}
}
