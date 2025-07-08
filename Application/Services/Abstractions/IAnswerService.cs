using Application.Dto;

namespace Application.Services.Abstractions;

public interface IAnswerService
{
    public Task<int> Create(AnswerRequest request);
}