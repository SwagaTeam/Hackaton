using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<LevelEntity> Levels { get; set; }
    public DbSet<TheoryEntity> Theories { get; set; }
    public DbSet<TestEntity> Tests { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<AnswerEntity> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка самореферентной связи для уровней
        modelBuilder.Entity<LevelEntity>()
            .HasOne(l => l.NextLevel)
            .WithOne()
            .HasForeignKey<LevelEntity>(l => l.NextLevelId)
            .OnDelete(DeleteBehavior.Restrict);

        // Связь вопрос-ответы
        modelBuilder.Entity<QuestionEntity>()
            .HasMany(q => q.Answers)
            .WithOne()
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);


        // Связь теста с вопросами
        modelBuilder.Entity<TestEntity>()
            .HasMany(t => t.Questions)
            .WithOne(q => q.Test)
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь уровня с теорией и тестом
        modelBuilder.Entity<LevelEntity>()
            .HasOne(l => l.Theory)
            .WithOne()
            .HasForeignKey<LevelEntity>(l => l.TheoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LevelEntity>()
            .HasOne(l => l.Test)
            .WithOne()
            .HasForeignKey<LevelEntity>(l => l.TestId)
            .OnDelete(DeleteBehavior.Cascade);


        // Уникальный логин пользователя
        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Login)
            .IsUnique();
    }
}