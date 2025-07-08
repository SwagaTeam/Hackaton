namespace Domain.Entities;

public class LevelEntity
{
    public int Id { get; set; }
    public int LevelNumber { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int? NextLevelId { get; set; }
    public int TheoryId { get; set; }
    public int ModuleId { get; set; }
    public virtual ModuleEntity Module { get; set; }
    public virtual TheoryEntity Theory { get; set; }
    public virtual ICollection<QuestionEntity> Questions { get; set; }
    public virtual LevelEntity? NextLevel { get; set; }
}