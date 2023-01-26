using TestPlatform.Application.DTOs;

namespace TestPlatform.Application.Interfaces.Service;

public interface IAnswerOptionService
{
    Task<IEnumerable<AnswerOptionDTO>> GetByQuestionId(int questionId);
}
