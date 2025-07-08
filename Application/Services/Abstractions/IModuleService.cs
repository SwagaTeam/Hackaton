
using Application.Dto;

namespace Application.Services.Abstractions;

public interface IModuleService
{
    public Task<int> Create(ModuleDto dto);
}