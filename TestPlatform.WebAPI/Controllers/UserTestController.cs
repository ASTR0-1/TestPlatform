using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;

namespace TestPlatform.WebAPI.Controllers;

[Authorize]
[Route("api/userTests")]
[ApiController]
public class UserTestController : ControllerBase
{
    private readonly IUserTestService _userTestService;

    public UserTestController(IUserTestService userTestService)
    {
        _userTestService = userTestService;
    }

    [HttpGet("test")]
    public async Task<IActionResult> GetByTestId([FromQuery] int testId)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByTestIdAsync(testId);

        return Ok(userTests);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetById(int userId)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByUserIdAsync(userId);

        return Ok(userTests);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetByEmail([FromQuery] string userEmail)
    {
        IEnumerable<UserTestDTO> userTests = await _userTestService.GetByUserEmailAsync(userEmail);

        return Ok(userTests);
    }
}
