using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository.Implementations;

public class ModuleRepository(AppDbContext context) : IModuleRepository
{
    public async Task<int> Create(string title)
    {
        var entity = new ModuleEntity();
        entity.Title = title;
        context.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
}