using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class RoleDataSeed : IEntityTypeConfiguration<IdentityRole<int>>
{
	public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
	{
		builder.HasData(
			new IdentityRole<int>
			{
				Id = 1,
				Name = "Administrator",
				NormalizedName = "ADMINISTRATOR",
			});
	}
}
