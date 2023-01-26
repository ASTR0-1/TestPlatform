namespace TestPlatform.Application.Interfaces.Service;

public interface IRoleService
{
    Task<IEnumerable<string>> GetUserRoles(string email);
}
