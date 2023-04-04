using Microsoft.AspNetCore.Authorization;
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
	public async Task<IActionResult> SignIn([FromBody] SignInDTO signInDTO)
	{
		User user = await _authService.SignIn(signInDTO);
		var roles = await _roleService.GetUserRoles(user.Email);

		string token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

		return Ok(new { user, roles, token });
	}

	[HttpPost("signUp")]
	public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDTO)
	{
		User user = await _authService.SignUp(signUpDTO);
		var roles = await _roleService.GetUserRoles(user.Email);

		string token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

		return Ok(new { user, token });
	}

	[Authorize]
	[HttpGet("logout")]
	public async Task<IActionResult> Logout()
	{
		await _authService.SignOut();

		Response.Cookies.Delete(".AspNetCore.Application.Id");

		return Ok();
	}
}
