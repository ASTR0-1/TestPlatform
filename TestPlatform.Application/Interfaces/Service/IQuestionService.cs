using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface IQuestionService
{
	Task<IEnumerable<QuestionDTO>> GetByTestId(int testId);
}
