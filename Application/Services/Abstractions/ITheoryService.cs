using Application.Dto;

namespace Application.Services.Abstractions;

public interface ITheoryService
{
    public Task<TheoryDto> GetById(int id);
    public Task<int> Create(TheoryDto theoryDto);
}