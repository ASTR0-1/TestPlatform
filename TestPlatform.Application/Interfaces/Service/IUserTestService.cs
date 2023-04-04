using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface IUserTestService
{
    Task<IEnumerable<UserTestDTO>> GetByUserEmailAsync(string email);

    Task<IEnumerable<UserTestDTO>> GetByTestIdAsync(int testId);
}
