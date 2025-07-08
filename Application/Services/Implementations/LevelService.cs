using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class LevelService(ILevelRepository repository) : ILevelService
{
    public async Task<int> Create(LevelDto dto)
    {
        if (dto.LevelNumber > 1)
        {
            var number = dto.LevelNumber;
            var prevLevel = await GetByNumber(number-1);
            prevLevel.NextLevelId = number;
        }
        var id = await repository.Create(dto.LevelNumber, dto.Name, dto.Difficulty, dto.NextLevelId, dto.TheoryId,
            dto.ModuleId);
        return id;
    }

    public async Task<LevelDto> GetById(int id)
    {
        var level = await repository.GetById(id);
        var dto = new LevelDto(level);
        return dto;
    }

    public async Task<LevelDto> GetByNumber(int number)
    {
        var level = await repository.GetByNumber(number);
        var dto = new LevelDto(level);
        return dto;
    }
}