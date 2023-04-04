using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Infrastructure.Persistence.DataSeeding;

public class UserDataSeed : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		var hasher = new PasswordHasher<IdentityUser>();

		builder.HasData(new User()
		{
			Id = 1,
			Email = "email1@gmail.com",
			NormalizedEmail = "EMAIL1@GMAIL.COM",
			UserName = "email1@gmail.com",
			NormalizedUserName = "EMAIL1@GMAIL.COM",
			PasswordHash = hasher.HashPassword(null, "passW0rd_1"),
			FirstName = "FN1",
			LastName = "LN1",
			SecurityStamp = Guid.NewGuid().ToString()
		});
		builder.HasData(new User()
		{
			Id = 2,
			Email = "email2@gmail.com",
			NormalizedEmail = "EMAIL2@GMAIL.COM",
			UserName = "email2@gmail.com",
			NormalizedUserName = "EMAIL2@GMAIL.COM",
			PasswordHash = hasher.HashPassword(null, "passW0rd_2"),
			FirstName = "FN2",
			LastName = "LN2",
			SecurityStamp = Guid.NewGuid().ToString()
		});
		builder.HasData(new User()
		{
			Id = 3,
			Email = "admin@gmail.com",
			NormalizedEmail = "ADMIN@GMAIL.COM",
			UserName = "admin@gmail.com",
			NormalizedUserName = "ADMIN@GMAIL.COM",
			PasswordHash = hasher.HashPassword(null, "admin_passW0rd"),
			FirstName = "AFN",
			LastName = "ALN",
			SecurityStamp = Guid.NewGuid().ToString(),
		});
	}
}
