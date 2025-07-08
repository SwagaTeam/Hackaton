namespace Domain.Entities;

public class AnswerEntity
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}