namespace Infrastructure.Repository.Abstractions;

public interface IQuestionRepository
{
    public Task<int> CreateAsync(string title, int testId);
}