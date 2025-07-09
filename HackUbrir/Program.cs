using System.Security.Claims;
using System.Text;
using Application.Middleware;
using Application.Quartz;
using Application.Quartz.Workers;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Application.Services.MailService;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddAuthentication(builder.Services, builder.Configuration);
        AddSwagger(builder.Services);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        string connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddInfrastructure(connString);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddScoped<IApiService, ApiService>();
        builder.Services.AddScoped<IQuestionService, QuestionService>();
        builder.Services.AddScoped<IAnswerService, AnswerService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuth, Auth>();
        builder.Services.AddScoped<IUserAnswerService, UserAnswerService>();
        builder.Services.AddScoped<IEncrypt, Encrypt>();
        builder.Services.AddScoped<ILevelService, LevelService>();
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<ITheoryService, TheoryService>();
        builder.Services.AddSingleton<IBlacklistService, BlacklistService>();
        builder.Services.AddSingleton<HttpClient>();

        builder.Services.Configure<MailSettings>(
            builder.Configuration.GetSection(nameof(MailSettings))
        );

        builder.Services.AddScoped<NotificationJob>();

        builder.Services.AddTransient<JobFactory>();
        builder.Services.AddTransient<IMailService, MailService>();
        builder.Services.AddScoped<IEmailSender, EmailSender>();

        builder.Services.AddHostedService<DataSchedulerService>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Важно: сначала CORS!
        app.UseCors("AllowAll");

        // Аутентификация и авторизация идут до твоего middleware
        app.UseAuthentication();
        app.UseAuthorization();

        // JwtBlacklistMiddleware после аутентификации
        app.UseMiddleware<JwtBlacklistMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        using var scope = app.Services.CreateScope();
        using var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await Migrate(appDbContext);

        await app.RunAsync();
    }

    private static void AddAuthentication(IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillingApplication API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Введите 'Bearer' и ваш JWT токен",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public static async Task Migrate(AppDbContext context)
    {
        await context.Database.MigrateAsync();
        await context.SaveChangesAsync();
    }
}
