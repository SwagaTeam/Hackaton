namespace Application.Dto;

using Domain.Entities;

public class QuestionRequest
{
    public string Title { get; set; }
    public int LevelId { get; set; }

    public QuestionRequest()
    {
        
    }

    public QuestionRequest(QuestionEntity entity)
    {
        Title = entity.Title;
        LevelId = entity.LevelId;
       
    }
}