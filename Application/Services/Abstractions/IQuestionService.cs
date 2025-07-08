using Application.Dto;

namespace Application.Services.Abstractions;

public interface IQuestionService
{
    public Task<int> Create(QuestionRequest request);
    public Task<QuestionResponse> GetById(int id);
    public Task<IEnumerable<QuestionResponse>> GetRandomQuestionsBelowLevel(int levelId);
}