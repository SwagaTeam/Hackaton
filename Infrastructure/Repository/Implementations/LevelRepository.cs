using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations;

public class LevelRepository(AppDbContext context)
{
    public async Task<int> Create(int levelNumber, string name, int difficulty, int? nextLevelId, int theoryId,
        int moduleId)
    {
        var entity = new LevelEntity();
        entity.LevelNumber = levelNumber;
        entity.Name = name;
        entity.Difficulty = difficulty;
        entity.NextLevelId = nextLevelId;
        entity.TheoryId = theoryId;
        entity.ModuleId = moduleId;
        context.Levels.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<LevelEntity> GetById(int id)
    {
        var entity = context.Levels
            .Include(l=>l.Theory)
            .FirstOrDefault(l=>l.Id == id);
        return entity;
    }

    public async Task<LevelEntity> GetByNumber(int number)
    {
        var entity = context.Levels
            .Include(l => l.Theory)
            .FirstOrDefault(l => l.LevelNumber == number);
        
        return entity;
    }
}