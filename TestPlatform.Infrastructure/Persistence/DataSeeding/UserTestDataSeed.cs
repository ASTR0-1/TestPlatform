using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class UserTestDataSeed : IEntityTypeConfiguration<UserTest>
{
    public void Configure(EntityTypeBuilder<UserTest> builder)
    {
        builder.HasData(new UserTest()
        {
            UserId = 1,
            TestId = 1,
        });
        builder.HasData(new UserTest()
        {
            UserId = 2,
            TestId = 2,
        });
    }
}
