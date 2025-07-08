namespace Infrastructure.Repository.Abstractions;

public interface ITestRepository
{
    public Task<int> CreateAsync();
}