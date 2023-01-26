using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Interfaces.Data;

public interface ITestRepository
{
    Task<IEnumerable<Test>> GetTestsAsync(bool trackChanges);

    Task<Test> GetTestAsync(int id, bool trackChanges);

    void CreateTest(Test test);

    void UpdateTest(Test test);

    void DeleteTest(int id);
}
