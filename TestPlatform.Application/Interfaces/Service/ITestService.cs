using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface ITestService
{
    Task<TestDTO> GetByTestId(int testId);

    Task<int> GetResultAsync(int testId, string email, int[] answers);
}
