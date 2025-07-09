using Domain.Entities;

namespace Application.Dto;

public class ModuleDtoRequest
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public ModuleDtoRequest(ModuleEntity entity)
    {
        Title = entity.Title;
        Text = entity.Text;
        Id = entity.Id;
    }

    public ModuleDtoRequest()
    {
        
    }
}