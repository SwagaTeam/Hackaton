using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class AnswerService(IAnswerRepository repository) : IAnswerService
{
    public async Task<int> Create(AnswerDto dto)
    {
        var id = await repository.Create(dto.QuestionId, dto.IsCorrect, dto.Text);
        return id;
    }

    public async Task<AnswerDto> GetById(int id)
    {
        var answer = await repository.GetById(id);
        var dto = new AnswerDto(answer);
        return dto;
    }
}