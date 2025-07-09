using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations;

public class ModuleRepository(AppDbContext context) : IModuleRepository
{
    public async Task<int> Create(string title)
    {
        var entity = new ModuleEntity();
        entity.Title = title;
        context.Modules.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<ModuleEntity> GetById(int id)
    {
        var module = await context.Modules
            .Include(x=>x.Levels)
            .FirstOrDefaultAsync(x => x.Id == id);

        return module;
    }

    public async Task<IEnumerable<ModuleEntity>> GetAll()
    {
        return context.Modules.Include(x=>x.Levels);
    }
}