using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestPlatform.Application.Helpers;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Application.Mappers;
using TestPlatform.Application.Services;
using TestPlatform.Domain.Entities;
using TestPlatform.Infrastructure.Persistence;
using TestPlatform.WebAPI.Extensions;

namespace TestPlatform.WebAPI;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		IServiceCollection services = builder.Services;
		IConfiguration configuration = builder.Configuration;

		services.AddDbContext<RepositoryContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("ProjectDB")));

		services.ConfigureCors();

		services.ConfigureEntityServices();
		services.AddScoped<IRepositoryManager, RepositoryManager>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IRoleService, RoleService>();
		services.AddAutoMapper(typeof(MappingProfile));

		services.AddIdentity<User, IdentityRole<int>>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 4;
			})
			.AddEntityFrameworkStores<RepositoryContext>()
			.AddDefaultTokenProviders();

		services.ConfigureApplicationCookie(options =>
		{
			options.Cookie.SameSite = SameSiteMode.None;
			options.Events.OnRedirectToLogin = context =>
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				return Task.CompletedTask;
			};
		});

		services.Configure<DataProtectionTokenProviderOptions>(opt =>
		opt.TokenLifespan = TimeSpan.FromHours(1));

		services.Configure<JwtSettings>(configuration.GetSection("JwtConfiguration"));

		services.AddAuthorization()
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer("Bearer", options =>
			{
				var jwtSettings = configuration.GetSection("JwtConfiguration").Get<JwtSettings>();

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = jwtSettings.Issuer,
					ValidAudience = jwtSettings.Issuer,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
					ClockSkew = TimeSpan.Zero
				};
			});

		services.AddControllers(config =>
		{
			config.RespectBrowserAcceptHeader = true;
			config.ReturnHttpNotAcceptable = true;
		}).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		var app = builder.Build();

		using (IServiceScope serviceScope = app.Services.CreateScope())
		{
			var serviceProvider = serviceScope.ServiceProvider;

			try
			{
				var dbContext = serviceScope.ServiceProvider.GetRequiredService<RepositoryContext>();

				dbContext.Database.Migrate();

				var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
				var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

				var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
				await userManager.AddToRoleAsync(adminUser, "Administrator");
			}
			catch (Exception ex)
			{
				app.Logger.Log(LogLevel.Warning, ex.Message);
			}
		}

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.ConfigureExceptionHandler();

		app.UseHttpsRedirection();

		app.UseCors("CorsPolicy");

		app.UseForwardedHeaders(new ForwardedHeadersOptions
		{
			ForwardedHeaders = ForwardedHeaders.All
		});

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}