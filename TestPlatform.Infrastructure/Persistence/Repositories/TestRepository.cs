using Microsoft.EntityFrameworkCore;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Repositories;

public class TestRepository : RepositoryBase<Test>, ITestRepository
{
	public TestRepository(RepositoryContext context)
		: base(context)
	{ }

	public void CreateTest(Test test) =>
		CreateTest(test);

	public void DeleteTest(Test test) =>
		DeleteTest(test);

	public async Task<Test> GetTestAsync(int id, bool trackChanges) =>
		await FindByCondition(t => t.Id == id, trackChanges)
			.Include(t => t.UserTests)
			.Include(t => t.Questions)
				.ThenInclude(q => q.AnswerOptions)
			.SingleOrDefaultAsync();

	public async Task<IEnumerable<Test>> GetTestsAsync(bool trackChanges) =>
		await FindAll(trackChanges)
			.Include(t => t.UserTests)
			.Include(t => t.Questions)
			.ToListAsync();

	public void UpdateTest(Test test) =>
		UpdateTest(test);
}
