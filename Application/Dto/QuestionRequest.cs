namespace Application.Dto;

using Domain.Entities;

public class QuestionRequest
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public int LevelId { get; set; }

    public QuestionRequest()
    {
        
    }

    public QuestionRequest(QuestionEntity entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        LevelId = entity.LevelId;
    }
}