using Domain.Entities;

namespace Application.Dto;

public class ModuleDtoResponse
{
    public string Title { get; set; }
    public List<LevelDtoRequest>? Levels { get; set; }

    public ModuleDtoResponse() { }

    public ModuleDtoResponse(ModuleEntity entity)
    {
        Title = entity.Title;
        Levels = entity.Levels is null
            ? new List<LevelDtoRequest>()
            : entity.Levels.Select(x => new LevelDtoRequest(x)).ToList();
    }
}