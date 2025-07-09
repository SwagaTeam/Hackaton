using Domain.Entities;

namespace Application.Dto;

public class ModuleDtoResponse
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Text { get; set; }
    
    public List<LevelDtoRequest>? Levels { get; set; }

    public ModuleDtoResponse() { }

    public ModuleDtoResponse(ModuleEntity entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Text = entity.Text;
        Levels = entity.Levels is null
            ? new List<LevelDtoRequest>()
            : entity.Levels.Select(x => new LevelDtoRequest(x)).ToList();
    }
}