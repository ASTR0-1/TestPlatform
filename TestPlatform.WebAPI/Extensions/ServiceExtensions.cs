using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Application.Services;

namespace TestPlatform.WebAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(opts =>
        {
            opts.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .WithExposedHeaders("X-Pagination"));
        });

    public static void ConfigureEntityServices(this IServiceCollection services)
    {
        services.AddScoped<IAnswerOptionService, AnswerOptionService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<IUserTestService, UserTestService>();
    }
}
