using Domain;
using Infrastructure.Repository.Abstractions;
using Infrastructure.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connString));

        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ILevelRepository, LevelRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITheoryRepository, TheoryRepository>();
        
        return services;
    }
}