using Application.Dto;

namespace Application.Services.Abstractions;

public interface IUserAnswerService
{
    public Task<UserAnswerResponse> GetCorrectSelectAnswers(UserAnswerRequest request);
}