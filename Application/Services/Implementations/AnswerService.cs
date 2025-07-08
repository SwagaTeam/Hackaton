using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class AnswerService(IAnswerRepository repository) : IAnswerService
{
    public async Task<int> Create(AnswerRequest request)
    {
        var id = await repository.Create(request.QuestionId, request.IsCorrect, request.Text);
        return id;
    }
}