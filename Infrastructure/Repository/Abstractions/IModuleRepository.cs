namespace Infrastructure.Repository.Abstractions;

public interface IModuleRepository
{
    public Task<int> Create(string title);
}