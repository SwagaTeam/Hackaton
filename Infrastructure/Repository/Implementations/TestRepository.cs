using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository.Implementations;

public class TestRepository(AppDbContext context) : ITestRepository
{
    public async Task<int> CreateAsync()
    {
        var entity = new TestEntity();
        context.Tests.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
}