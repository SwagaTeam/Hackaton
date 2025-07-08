using Domain.Entities;

namespace Infrastructure.Repository.Abstractions;

public interface ITheoryRepository
{
    public Task<int> CreateAsync(string title, string text);
    public Task<TheoryEntity> GetByIdAsync(int id);

}