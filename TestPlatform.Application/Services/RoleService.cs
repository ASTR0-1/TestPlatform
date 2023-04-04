using Microsoft.AspNetCore.Identity;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class RoleService : IRoleService
{
	private readonly UserManager<User> _userManager;

	public RoleService(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IEnumerable<string>> GetUserRoles(string email)
	{
		var user = await _userManager.FindByEmailAsync(email);

		return user == null
			? throw new KeyNotFoundException($"User with email \"{email}\" doesn't exist")
			: (IEnumerable<string>)await _userManager.GetRolesAsync(user);
	}
}
