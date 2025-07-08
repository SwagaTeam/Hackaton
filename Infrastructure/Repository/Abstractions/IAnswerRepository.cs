namespace Infrastructure.Repository.Abstractions;

public interface IAnswerRepository
{
    public Task<int> Create(int questionId, bool isCorrect, string text);
}