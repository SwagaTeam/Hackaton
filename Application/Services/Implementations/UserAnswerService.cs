using Application.Dto;
using Application.Services.Abstractions;

namespace Application.Services.Implementations;

public class UserAnswerService(IQuestionService questionService) : IUserAnswerService
{
    public async Task<UserAnswerResponse> GetCorrectSelectAnswers(UserAnswerRequest request)
    {
        var correctAnswers = (await questionService.GetById(request.QuestionId))
            .Answers
            .Where(a => a.IsCorrect)
            .Select(a => a.Id)
            .ToHashSet(); 

        var userAnswers = request.SelectedAnswers.ToHashSet();

        var isAllAnswersCorrect = correctAnswers.SetEquals(userAnswers);

        var correctSelected = userAnswers.Intersect(correctAnswers).ToList();

        return new UserAnswerResponse
        {
            CorrectAnswers = correctSelected,
            IsAllAnswersCorrect = isAllAnswersCorrect
        };
    }

}