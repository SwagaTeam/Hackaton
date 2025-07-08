using Application.Dto;

namespace Application.Services.Abstractions;

public interface ILevelService
{
    public Task<LevelDtoResponse> GetById(int id);
    public Task<int> Create(LevelDtoRequest request);
    public Task<LevelDtoResponse> GetByNumber(int number);
}