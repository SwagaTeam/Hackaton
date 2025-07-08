using Domain.Entities;

namespace Application.Dto;

public class AnswerDto
{
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    public string Text { get; set; }

    public AnswerDto(AnswerEntity entity)
    {
        QuestionId = entity.QuestionId;
        IsCorrect = entity.IsCorrect;
        Text = entity.Text;
    }

    public AnswerDto()
    {
        
    }
}