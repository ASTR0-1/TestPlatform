using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
	public void Configure(EntityTypeBuilder<Test> builder)
	{
		builder.Property(t => t.Title)
			.IsRequired();

		builder.Property(t => t.Description)
			.IsRequired();

		builder.Property(t => t.QuestionCount)
			.IsRequired();
	}
}
