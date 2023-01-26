using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Interfaces.Data;

public interface IUserTestRepository
{
    Task<IEnumerable<UserTest>> GetUserTestsAsync(bool trackChanges);

    Task<UserTest> GetUserTestAsync(int id, bool trackChanges);

    void CreateUserTest(UserTest userTest);

    void UpdateUserTest(UserTest userTest);

    void DeleteUserTest(int id);
}
