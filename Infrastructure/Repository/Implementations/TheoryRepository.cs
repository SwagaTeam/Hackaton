using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository.Implementations;

public class TheoryRepository(AppDbContext context) : ITheoryRepository
{
    public async Task<int> CreateAsync(string title, string text)
    {
        var entity = new TheoryEntity();
        entity.Title = title;
        entity.Text = text;
        context.Theories.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<TheoryEntity> GetByIdAsync(int id)
    {
        var theory = await context.Theories.FindAsync(id);
        return theory;
    }
}