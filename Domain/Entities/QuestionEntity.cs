namespace Domain.Entities;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int TestId { get; set; }
    public virtual TestEntity Test { get; set; }
    public virtual ICollection<AnswerEntity> Answers { get; set; } // Варианты ответов
}