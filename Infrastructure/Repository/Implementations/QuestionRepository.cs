using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations;

public class QuestionRepository(AppDbContext context) : IQuestionRepository
{
    public async Task<int> CreateAsync(string title, int levelId)
    {
        var entity = new QuestionEntity();
        entity.Title = title;
        entity.LevelId = levelId;
        context.Questions.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<QuestionEntity> GetById(int id)
    {
        var entity = await context.Questions
            .Include(q => q.Level)
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.Id == id);
        return entity;
    }

    public async Task<IEnumerable<QuestionEntity>> GetRandomQuestionsBelowLevel(int levelId)
    {
        return await context.Questions
            .Include(q => q.Level)
            .Include(q => q.Answers)
            .Where(q=>q.Level.LevelNumber <= levelId)
            .OrderBy(q=>Guid.NewGuid())
            .Take(10)
            .ToListAsync();
    }
}