using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence;

public class RepositoryContext : IdentityDbContext<User, IdentityRole<int>, int>
{
	public RepositoryContext(DbContextOptions<RepositoryContext> options)
		: base(options)
	{
	}

	public DbSet<Test> Tests { get; set; }

	public DbSet<Question> Question { get; set; }

	public DbSet<AnswerOption> AnswerOptions { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}
}
