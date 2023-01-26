using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface IUserTestService
{
    Task<UserTestDTO> GetByUserEmailAsync(string email);

    Task<UserTestDTO> GetByUserIdAsync(int userId);

    Task<UserTestDTO> GetByTestIdAsync(int testId);
}
