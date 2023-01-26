using System.Reflection;
using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface ITestService
{
    Task<IEnumerable<TestDTO>> GetByEmailAsync(string email);

    Task<int> GetResultAsync(int testId, string email, int[] answers);
}
