using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class TestDataSeed : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasData(new Test()
        {
            Id = 1,
            Title = "Test1",
            Description = "Description for test1",
            QuestionCount = 4,
        });
        
        builder.HasData(new Test()
        {
            Id = 2,
            Title = "Test2",
            Description = "Description for test2",
            QuestionCount = 4,
        });
    }
}
