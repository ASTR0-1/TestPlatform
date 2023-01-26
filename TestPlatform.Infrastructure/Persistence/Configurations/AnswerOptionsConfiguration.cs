using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Configurations;

public class AnswerOptionsConfiguration : IEntityTypeConfiguration<AnswerOption>
{
    public void Configure(EntityTypeBuilder<AnswerOption> builder)
    {
        builder.Property(ao => ao.OptionNumber)
            .IsRequired();

        builder.Property(ao => ao.OptionText)
            .IsRequired();

        builder.Property(ao => ao.IsCorrect)
            .IsRequired();
    }
}
