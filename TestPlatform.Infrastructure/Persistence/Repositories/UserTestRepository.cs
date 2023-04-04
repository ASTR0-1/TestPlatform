using Microsoft.EntityFrameworkCore;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Repositories;

public class UserTestRepository : RepositoryBase<UserTest>, IUserTestRepository
{
	public UserTestRepository(RepositoryContext context)
		: base(context)
	{ }

	public void CreateUserTest(UserTest userTest) =>
		Create(userTest);

	public void DeleteUserTest(UserTest userTest) =>
		Delete(userTest);

	public async Task<IEnumerable<UserTest>> GetUserTestsAsync(bool trackChanges) =>
		await FindAll(trackChanges)
			.Include(ut => ut.User)
			.Include(ut => ut.Test)
			.ToListAsync();

	public void UpdateUserTest(UserTest userTest) =>
		Update(userTest);
}
