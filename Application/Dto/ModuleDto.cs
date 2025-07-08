using Domain.Entities;

namespace Application.Dto;

public class ModuleDto
{
    public string Title { get; set; }

    public ModuleDto()
    {
        
    }

    public ModuleDto(ModuleEntity entity)
    {
        Title = entity.Title;
    }
}