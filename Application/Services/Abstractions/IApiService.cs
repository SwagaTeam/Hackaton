namespace Application.Services.Abstractions;

public interface IApiService
{
    public Task<string> GetSummaryAsync(string content);
    public Task<string> AskQuestionAsync(string question, string block);
}