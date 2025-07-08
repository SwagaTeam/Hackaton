namespace Domain.Entities;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LevelId { get; set; }
    public virtual LevelEntity Level { get; set; }
    public virtual ICollection<AnswerEntity> Answers { get; set; } // Варианты ответов
}