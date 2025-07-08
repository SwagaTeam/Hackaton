using Domain.Entities;

namespace Application.Dto;

public class LevelDto
{
    public int LevelNumber { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int? NextLevelId { get; set; }
    public int TheoryId { get; set; }
    public int ModuleId { get; set; }
    public TheoryDto Theory { get; set; }
    public LevelDto NextLevel { get; set; }
    public List<QuestionDto> Questions { get; set; }
    public ModuleDto Module { get; set; }

    public LevelDto(LevelEntity entity)
    {
        LevelNumber = entity.LevelNumber;
        Name = entity.Name;
        Difficulty = entity.Difficulty;
        NextLevelId = entity.NextLevelId;
        TheoryId = entity.TheoryId;
        ModuleId = entity.ModuleId;
        Theory = new TheoryDto(entity.Theory.Title, entity.Theory.Text);
        NextLevel = entity.NextLevel is null ? null : new LevelDto(entity.NextLevel);
        Questions = entity.Questions.Select(x => new QuestionDto(x)).ToList();
        Module = new ModuleDto(entity.Module);
    }

    public LevelDto()
    {
        
    }
}