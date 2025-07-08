using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository.Implementations;

public class QuestionRepository(AppDbContext context) : IQuestionRepository
{
    public async Task<int> CreateAsync(string title, int testId)
    {
        var entity = new QuestionEntity();
        entity.Title = title;
        entity.TestId = testId;
        context.Questions.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
}