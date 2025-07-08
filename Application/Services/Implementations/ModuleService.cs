using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class ModuleService(IModuleRepository repository) : IModuleService
{
    public async Task<int> Create(ModuleDtoRequest dtoResponse)
    {
        var id = await repository.Create(dtoResponse.Title);
        return id;
    }

    public async Task<ModuleDtoResponse> GetById(int id)
    {
        var module = await repository.GetById(id);
        var dto = new ModuleDtoResponse(module);
        return dto;
    }
}