using Domain.Entities;

namespace Infrastructure.Repository.Abstractions;

public interface IQuestionRepository
{
    public Task<int> CreateAsync(string title, int testId);
    public Task<QuestionEntity> GetById(int id);
    public Task<IEnumerable<QuestionEntity>> GetRandomQuestionsBelowLevel(int levelId);
}