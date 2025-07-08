using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class QuestionService(IQuestionRepository repository) : IQuestionService
{
    public async Task<int> Create(QuestionRequest request)
    {
        var id = await repository.CreateAsync(request.Title, request.TestId);
        return id;
    }
}