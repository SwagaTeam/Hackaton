using Domain.Entities;

namespace Application.Dto;

public class ModuleDtoRequest
{
    public string Title { get; set; }

    public ModuleDtoRequest(ModuleEntity entity)
    {
        Title = entity.Title;
    }

    public ModuleDtoRequest()
    {
        
    }
}