using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository.Implementations;

public class AnswerRepository(AppDbContext context) : IAnswerRepository
{
    public async Task<int> Create(int questionId, bool isCorrect, string text)
    {
        var entity = new AnswerEntity();
        entity.QuestionId = questionId;
        entity.IsCorrect = isCorrect;
        entity.Text = text;
        context.Answers.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<AnswerEntity> GetById(int id)
    {
        var entity = await context.Answers.FindAsync(id);
        return entity;
    }
}