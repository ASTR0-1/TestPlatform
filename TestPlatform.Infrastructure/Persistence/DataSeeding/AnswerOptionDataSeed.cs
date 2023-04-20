using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class AnswerOptionDataSeed : IEntityTypeConfiguration<AnswerOption>
{
	public void Configure(EntityTypeBuilder<AnswerOption> builder)
	{
		builder.HasData(new AnswerOption()
		{
			Id = 1,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = true,
			QuestionId = 1,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 2,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = false,
			QuestionId = 1,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 3,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = false,
			QuestionId = 1,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 4,
			OptionNumber = 4,
			OptionText = "OptionText4",
			IsCorrect = false,
			QuestionId = 1,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 5,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 2,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 6,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = true,
			QuestionId = 2,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 7,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = false,
			QuestionId = 2,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 8,
			OptionNumber = 4,
			OptionText = "OptionText4",
			IsCorrect = false,
			QuestionId = 2,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 9,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 3,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 10,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = true,
			QuestionId = 3,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 11,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 4,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 12,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = false,
			QuestionId = 4,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 13,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = true,
			QuestionId = 4,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 14,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = true,
			QuestionId = 5,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 15,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = false,
			QuestionId = 5,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 16,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = false,
			QuestionId = 5,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 17,
			OptionNumber = 4,
			OptionText = "OptionText4",
			IsCorrect = false,
			QuestionId = 5,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 18,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 6,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 19,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = true,
			QuestionId = 6,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 20,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = false,
			QuestionId = 6,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 21,
			OptionNumber = 4,
			OptionText = "OptionText4",
			IsCorrect = false,
			QuestionId = 6,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 22,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 7,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 23,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = true,
			QuestionId = 7,
		});

		builder.HasData(new AnswerOption()
		{
			Id = 24,
			OptionNumber = 1,
			OptionText = "OptionText1",
			IsCorrect = false,
			QuestionId = 8,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 25,
			OptionNumber = 2,
			OptionText = "OptionText2",
			IsCorrect = false,
			QuestionId = 8,
		});
		builder.HasData(new AnswerOption()
		{
			Id = 26,
			OptionNumber = 3,
			OptionText = "OptionText3",
			IsCorrect = true,
			QuestionId = 8,
		});
	}
}
