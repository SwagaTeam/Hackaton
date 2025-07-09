namespace Application.Dto;

public class ShortDescriptionRequest
{
    public string Content { get; set; }

    public ShortDescriptionRequest(string content)
    {
        Content = content;
    }
}