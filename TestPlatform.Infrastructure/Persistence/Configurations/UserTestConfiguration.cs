using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.Configurations;

public class UserTestConfiguration : IEntityTypeConfiguration<UserTest>
{
    public void Configure(EntityTypeBuilder<UserTest> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.TestId });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTests)
            .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.Test)
            .WithMany(t => t.UserTests)
            .HasForeignKey(ut => ut.TestId);
    }
}
