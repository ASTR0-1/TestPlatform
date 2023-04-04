using Microsoft.EntityFrameworkCore;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Repositories;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
{
	public QuestionRepository(RepositoryContext context)
		: base(context)
	{ }

	public void CreateQuestion(Question question) =>
		Create(question);

	public void DeleteQuestion(Question question) =>
		Delete(question);

	public async Task<Question> GetQuestionAsync(int id, bool trackChanges) =>
		await FindByCondition(q => q.Id == id, trackChanges)
			.Include(q => q.AnswerOptions)
			.SingleOrDefaultAsync();

	public async Task<IEnumerable<Question>> GetQuestionsAsync(bool trackChanges) =>
		await FindAll(trackChanges)
			.Include(q => q.AnswerOptions)
			.ToListAsync();

	public void UpdateQuestion(Question question) =>
		Update(question);
}
