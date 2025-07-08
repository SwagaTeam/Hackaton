using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class QuestionService(IQuestionRepository repository) : IQuestionService
{
    public async Task<int> Create(QuestionDto dto)
    {
        var id = await repository.CreateAsync(dto.Title, dto.LevelId);
        return id;
    }
}