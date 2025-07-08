using Application.Middleware;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));
        builder.Services.AddScoped<IApiService, ApiService>();
        builder.Services.AddScoped<IQuestionService, QuestionService>();
        builder.Services.AddScoped<IAnswerService, AnswerService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuth, Auth>();
        builder.Services.AddScoped<IEncrypt, Encrypt>();
        builder.Services.AddScoped<ILevelService, LevelService>();
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<ITheoryService, TheoryService>();
        builder.Services.AddScoped<IBlacklistService, BlacklistService>();
        builder.Services.AddSingleton<HttpClient>();


        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        using var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await Migrate(appDbContext);

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseMiddleware<JwtBlacklistMiddleware>();
        app.MapControllers();

        await app.RunAsync();
    }

    public static async Task Migrate(AppDbContext context)
    {
        await context.Database.MigrateAsync();
        await context.SaveChangesAsync();
    }
}