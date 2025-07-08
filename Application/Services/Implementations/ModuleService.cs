using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class ModuleService(IModuleRepository repository) : IModuleService
{
    public async Task<int> Create(ModuleDto dto)
    {
        var id = await repository.Create(dto.Title);
        return id;
    }
}