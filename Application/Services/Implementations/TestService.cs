using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class TestService(ITestRepository repository) : ITestService
{
    public async Task<int> Create()
    {
        return await repository.CreateAsync();
    }
}