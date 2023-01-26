using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Helpers;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.WebAPI.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;
    private readonly IAuthService _authService;
    private readonly IRoleService _roleService;

    public AccountController(IOptionsSnapshot<JwtSettings> jwtSettings, IAuthService authService, IRoleService roleService)
    {
        _jwtSettings = jwtSettings.Value;
        _authService = authService;
        _roleService = roleService;
    }

    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn(SignInDTO signInDTO)
    {
        User user;
        string token;

        try
        {
            user = await _authService.SignIn(signInDTO);

            var roles = await _roleService.GetUserRoles(user.Email);

            token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token,
                    new CookieOptions
                    {
                        MaxAge = TimeSpan.FromDays(Convert.ToDouble(_jwtSettings.Lifetime)),
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(new { user, token });
    }

    [HttpPost("signUp")]
    public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
    {
        User user;
        string token;

        try
        {
            user = await _authService.SignUp(signUpDTO);

            var roles = await _roleService.GetUserRoles(user.Email);

            token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token,
                    new CookieOptions
                    {
                        MaxAge = TimeSpan.FromDays(Convert.ToDouble(_jwtSettings.Lifetime)),
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(new { user, token });
    }

    [Authorize]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _authService.SignOut();

            Response.Cookies.Delete(".AspNetCore.Application.Id");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}
