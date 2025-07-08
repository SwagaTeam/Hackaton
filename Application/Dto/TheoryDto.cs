namespace Application.Dto;

public class TheoryDto
{
    public string Title { get; set; }
    public string Text { get; set; }

    public TheoryDto(string title, string text)
    {
        Title = title;
        Text = text;
    }

    public TheoryDto()
    {
        
    }
}