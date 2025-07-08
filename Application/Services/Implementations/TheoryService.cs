using Application.Dto;
using Application.Services.Abstractions;
using Infrastructure.Repository.Abstractions;

namespace Application.Services.Implementations;

public class TheoryService(ITheoryRepository repository) : ITheoryService
{
    public async Task<int> Create(TheoryDto dto)
    {
        var id = await repository.CreateAsync(dto.Title, dto.Text);
        return id;
    }

    public async Task<TheoryDto> GetById(int id)
    {
        var theory = await repository.GetByIdAsync(id);
        var dto = new TheoryDto(theory.Title, theory.Text);
        return dto;
    }
}