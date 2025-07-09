
using Application.Dto;

namespace Application.Services.Abstractions;

public interface IModuleService
{
    public Task<int> Create(ModuleDtoRequest dtoResponse);
    public Task<ModuleDtoResponse> GetById(int id);
    public Task<IEnumerable<ModuleDtoResponse>> GetAll();
}