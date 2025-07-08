using Application.Dto;

namespace Application.Services.Abstractions;

public interface IQuestionService
{
    public Task<int> Create(QuestionDto dto);
}