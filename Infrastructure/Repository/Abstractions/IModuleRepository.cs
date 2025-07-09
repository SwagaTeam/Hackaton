using Domain.Entities;

namespace Infrastructure.Repository.Abstractions;

public interface IModuleRepository
{
    public Task<int> Create(string title, string text);
    public Task<ModuleEntity> GetById(int id);
    public Task<IEnumerable<ModuleEntity>> GetAll();
}