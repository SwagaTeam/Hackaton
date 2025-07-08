namespace Application.Dto;

public class UserAnswerResponse
{
    public List<int> CorrectAnswers { get; set; }
    public bool IsAllAnswersCorrect { get; set; }
}