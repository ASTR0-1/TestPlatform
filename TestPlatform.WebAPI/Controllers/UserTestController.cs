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

    [Authorize(Roles = "Administrator")]
    [HttpGet("test")]
    public async Task<IActionResult> GetAllByTestId([FromQuery] int testId)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByTestIdAsync(testId);

        return Ok(userTests);
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllByUserId(int userId)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByUserIdAsync(userId);

        return Ok(userTests);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserTests()
    {
        IEnumerable<UserTestDTO> userTests = await _userTestService.GetByUserEmailAsync(User.Identity.Name);

        return Ok(userTests);
    }
}
