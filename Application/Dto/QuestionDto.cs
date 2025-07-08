using Domain.Entities;

namespace Application.Dto;

public class QuestionDto
{
    public string Title { get; set; }
    public int LevelId { get; set; }
    public List<AnswerDto> Answers { get; set; }
    public LevelDto Level { get; set; }

    public QuestionDto()
    {
        
    }

    public QuestionDto(QuestionEntity entity)
    {
        Title = entity.Title;
        LevelId = entity.LevelId;
        Answers = entity.Answers.Select(a => new AnswerDto(a)).ToList();
        Level = new LevelDto(entity.Level);
    }
}