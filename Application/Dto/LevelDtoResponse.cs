using Domain.Entities;

namespace Application.Dto;

public class LevelDtoResponse
{
    public int Id { get; private set; }
    public int LevelNumber { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int? NextLevelId { get; set; }
    public int TheoryId { get; set; }
    public int ModuleId { get; set; }

    public TheoryDto? Theory { get; set; }
    public LevelDtoResponse? NextLevel { get; set; }
    public List<QuestionRequest>? Questions { get; set; }
    public ModuleDtoRequest? Module { get; set; }

    public LevelDtoResponse(LevelEntity entity)
    {
        Id = entity.Id;
        LevelNumber = entity.LevelNumber;
        Name = entity.Name;
        Difficulty = entity.Difficulty;
        NextLevelId = entity.NextLevelId;
        TheoryId = entity.TheoryId;
        ModuleId = entity.ModuleId;

        Theory = entity.Theory is null ? null : new TheoryDto(entity.Theory.Title, entity.Theory.Text);
        NextLevel = entity.NextLevel is null ? null : new LevelDtoResponse(entity.NextLevel);
        Questions = entity.Questions is null ? new List<QuestionRequest>() : entity.Questions.Select(x => new QuestionRequest(x)).ToList();
        Module = entity.Module is null ? null : new ModuleDtoRequest(entity.Module);
    }

    public LevelDtoResponse() { }
}