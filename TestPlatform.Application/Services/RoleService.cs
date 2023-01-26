using Microsoft.AspNetCore.Identity;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;

    public RoleService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<string>> GetUserRoles(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new ArgumentException($"User with email \"{email}\" doesn't exists");

        return await _userManager.GetRolesAsync(user);
    }
}
