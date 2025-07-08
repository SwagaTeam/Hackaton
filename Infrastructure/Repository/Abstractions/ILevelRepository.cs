using Domain.Entities;

namespace Infrastructure.Repository.Abstractions;

public interface ILevelRepository
{
    public Task<int> Create(int levelNumber, string name, int difficulty, int? nextLevelId, int theoryId,
        int moduleId);

    public Task<LevelEntity> GetById(int id);
    public Task<LevelEntity> GetByNumber(int number);
    public Task SaveNextLevelId(int id, int nextLevelId);

}