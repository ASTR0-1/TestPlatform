using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Interfaces.Data;

public interface IAnswerOptionRepository
{
    Task<IEnumerable<AnswerOption>> GetAnswerOptionsAsync(bool trackChanges);

    Task<AnswerOption> GetAnswerOptionAsync(int id, bool trackChanges);

    void CreateAnswerOption(AnswerOption answerOption);

    void UpdateAnswerOption(AnswerOption answerOption);

    void DeleteAnswerOption(AnswerOption answerOption);
}
