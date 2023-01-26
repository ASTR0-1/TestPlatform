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

    [HttpGet]
    public async Task<IActionResult> GetByEmail([FromQuery] string userEmail)
    {
        IEnumerable<TestDTO> tests;

        try
        {
            tests = await _testService.GetByEmailAsync(userEmail);
        }
        catch
        {
            return BadRequest();
        }

        return Ok(tests);
    }

    [HttpGet("result")]
    public async Task<IActionResult> GetResult([FromQuery] int testId, [FromQuery] string userEmail, [FromQuery] int[] answers)
    {
        int result;

        try
        {
            result = await _testService.GetResultAsync(testId, userEmail, answers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(result);
    }
}
