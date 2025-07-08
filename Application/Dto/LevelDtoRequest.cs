using Domain.Entities;

namespace Application.Dto;

public class LevelDtoRequest
{
    public int Id { get; private set; }
    public int LevelNumber { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int? NextLevelId { get; set; }
    public int TheoryId { get; set; }
    public int ModuleId { get; set; }

    public LevelDtoRequest(LevelEntity entity)
    {
        Id = entity.Id;
        LevelNumber = entity.LevelNumber;
        Name = entity.Name;
        Difficulty = entity.Difficulty;
        NextLevelId = entity.NextLevelId;
        TheoryId = entity.TheoryId;
        ModuleId = entity.ModuleId;
    }
}