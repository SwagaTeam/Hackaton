using Domain.Entities;

namespace Application.Dto;

public class QuestionResponse
{
    public string Title { get; set; }
    public int LevelId { get; set; }
    public List<AnswerDto>? Answers { get; set; }
    public LevelDtoRequest? Level { get; set; }

    public QuestionResponse()
    {
        
    }

    public QuestionResponse(QuestionEntity entity)
    {
        Title = entity.Title;
        LevelId = entity.LevelId;
        Answers = entity.Answers is null ? null : entity.Answers.Select(a => new AnswerDto(a)).ToList();
        Level = entity.Level is null ? null : new LevelDtoRequest(entity.Level);
    }
}