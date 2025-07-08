using Application.Dto;

namespace Application.Services.Abstractions;

public interface IAnswerService
{
    public Task<int> Create(AnswerDto dto);
    public Task<AnswerDto> GetById(int id);
}