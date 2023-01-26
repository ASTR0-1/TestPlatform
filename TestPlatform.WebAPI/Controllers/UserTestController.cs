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

    [HttpGet]
    public async Task<IActionResult> GetByTestId([FromQuery] int id, [FromQuery] string idType)
    {
        UserTestDTO userTest;

        try
        {
            if (idType == "testId")
                userTest = await _userTestService.GetByTestIdAsync(id);
            else
                userTest = await _userTestService.GetByUserIdAsync(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(userTest);
    }
}
