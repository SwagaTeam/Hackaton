namespace Application.Dto;

public class UserAnswerRequest
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public List<int> SelectedAnswers { get; set; }
}