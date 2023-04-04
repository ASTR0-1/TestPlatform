using Microsoft.AspNetCore.Diagnostics;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Application.Services;
using TestPlatform.Domain.Exceptions;

namespace TestPlatform.WebAPI.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(opts =>
		{
			opts.AddPolicy("CorsPolicy", builder =>
				builder.AllowAnyHeader()
				.AllowAnyMethod()
				.WithOrigins("http://localhost:4200")
				.AllowCredentials());
		});

	public static void ConfigureEntityServices(this IServiceCollection services)
	{
		services.AddScoped<IAnswerOptionService, AnswerOptionService>();
		services.AddScoped<IQuestionService, QuestionService>();
		services.AddScoped<ITestService, TestService>();
		services.AddScoped<IUserTestService, UserTestService>();
	}

	public static void ConfigureExceptionHandler(this IApplicationBuilder app)
	{
		app.UseExceptionHandler(appError =>
		{
			appError.Run(async context =>
			{
				context.Response.ContentType = "application/json";

				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

				if (contextFeature != null)
				{
					context.Response.StatusCode = contextFeature.Error switch
					{
						UserAuthenticationException => StatusCodes.Status401Unauthorized,
						KeyNotFoundException => StatusCodes.Status404NotFound,
						InvalidOperationException => StatusCodes.Status400BadRequest,
						_ => StatusCodes.Status500InternalServerError
					};

					await context.Response.WriteAsync(new
					{
						context.Response.StatusCode,
						contextFeature.Error.Message
					}.ToString());
				}
			});
		});
	}
}
