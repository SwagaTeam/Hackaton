using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class LevelService(ILevelRepository repository) : ILevelService
{
    public async Task<int> Create(LevelDtoRequest request)
    {
        var id = await repository.Create(request.LevelNumber, request.Name, request.Difficulty, request.NextLevelId, request.TheoryId,
            request.ModuleId);
        if (request.LevelNumber > 1)
        {
            var number = request.LevelNumber;
            var prevLevel = await GetByNumber(number-1);
            await repository.SaveNextLevelId(prevLevel.Id, id);
        }
        
        return id;
    }

    public async Task<LevelDtoResponse> GetById(int id)
    {
        var level = await repository.GetById(id);
        var dto = new LevelDtoResponse(level);
        return dto;
    }

    public async Task<LevelDtoResponse> GetByNumber(int number)
    {
        var level = await repository.GetByNumber(number);
        var dto = new LevelDtoResponse(level);
        return dto;
    }
}