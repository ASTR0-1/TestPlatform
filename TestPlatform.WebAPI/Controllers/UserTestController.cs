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
    [HttpGet("test/{testId}")]
    public async Task<IActionResult> GetAllByTestId(int testId)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByTestIdAsync(testId);

        return Ok(userTests);
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("user")]
    public async Task<IActionResult> GetAllByUserEmail([FromQuery] string userEmail)
    {
        IEnumerable<UserTestDTO> userTests;

        userTests = await _userTestService.GetByUserEmailAsync(userEmail);

        return Ok(userTests);
    }

    [HttpGet("currentUser")]
    public async Task<IActionResult> GetAllUserTests()
    {
        IEnumerable<UserTestDTO> userTests = await _userTestService.GetByUserEmailAsync(User.Identity.Name);

        return Ok(userTests);
    }
}
