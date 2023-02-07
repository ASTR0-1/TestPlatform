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
    [HttpGet]
    public async Task<IActionResult> GetByUserEmail([FromQuery] string userEmail)
    {
        IEnumerable<TestDTO> tests = await _testService.GetByEmailAsync(userEmail);
        
        return Ok(tests);
    }

    [HttpGet("result")]
    public async Task<IActionResult> GetResult([FromQuery] int testId, [FromQuery] int[] answers)
    {
        int result = await _testService.GetResultAsync(testId, User.Identity.Name, answers);

        return Ok(result);
    }
}
