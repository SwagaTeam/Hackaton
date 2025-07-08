using Application.Dto;

namespace Application.Services.Abstractions;

public interface ILevelService
{
    public Task<LevelDto> GetById(int id);
    public Task<int> Create(LevelDto dto);
    public Task<LevelDto> GetByNumber(int number);
}