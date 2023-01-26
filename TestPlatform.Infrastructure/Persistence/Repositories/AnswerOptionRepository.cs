using Microsoft.EntityFrameworkCore;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Repositories;

public class AnswerOptionRepository : RepositoryBase<AnswerOption>, IAnswerOptionRepository
{
    public AnswerOptionRepository(RepositoryContext context)
        : base(context)
    { }

    public void CreateAnswerOption(AnswerOption answerOption) =>
        Create(answerOption);

    public void DeleteAnswerOption(AnswerOption answerOption) =>
        Delete(answerOption);

    public async Task<AnswerOption> GetAnswerOptionAsync(int id, bool trackChanges) =>
        await FindByCondition(ao => ao.Id == id, trackChanges)
            .Include(ao => ao.Question)
            .SingleOrDefaultAsync();

    public async Task<IEnumerable<AnswerOption>> GetAnswerOptionsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .Include(ao => ao.Question)
            .ToListAsync();

    public void UpdateAnswerOption(AnswerOption answerOption) =>
        Update(answerOption);
}
