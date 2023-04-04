using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class QuestionDataSeed : IEntityTypeConfiguration<Question>
{
	public void Configure(EntityTypeBuilder<Question> builder)
	{
		builder.HasData(new Question()
		{
			Id = 1,
			QuestionNumber = 1,
			QuestionText = "Question1",
			TestId = 1
		});
		builder.HasData(new Question()
		{
			Id = 2,
			QuestionNumber = 2,
			QuestionText = "Question2",
			TestId = 1
		});
		builder.HasData(new Question()
		{
			Id = 3,
			QuestionNumber = 3,
			QuestionText = "Question3",
			TestId = 1
		});
		builder.HasData(new Question()
		{
			Id = 4,
			QuestionNumber = 4,
			QuestionText = "Question4",
			TestId = 1
		});

		builder.HasData(new Question()
		{
			Id = 5,
			QuestionNumber = 1,
			QuestionText = "Question1",
			TestId = 2
		});
		builder.HasData(new Question()
		{
			Id = 6,
			QuestionNumber = 2,
			QuestionText = "Question2",
			TestId = 2
		});
		builder.HasData(new Question()
		{
			Id = 7,
			QuestionNumber = 3,
			QuestionText = "Question3",
			TestId = 2
		});
		builder.HasData(new Question()
		{
			Id = 8,
			QuestionNumber = 4,
			QuestionText = "Question4",
			TestId = 2
		});
	}
}
