namespace Application.Dto;

public class AnswerRequest
{
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }
}