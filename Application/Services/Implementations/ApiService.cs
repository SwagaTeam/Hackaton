using System.Text;
using System.Text.Json;
using Application.Services.Abstractions;

namespace Application.Services.Implementations;

public class ApiService : IApiService
{
    private readonly string apiKey = "AIzaSyAn7Rn4z2fk0kGhs_AlurMmXKeF_3S2YhM";

    private readonly string geminiUrl =
        "https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent";

    private readonly HttpClient httpClient;

    public ApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetSummaryAsync(string content)
    {
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    role = "user",
                    parts = new[]
                    {
                        new { text = "Ты помогаешь студенту понять учебный материал. Выдели ключевые идеи кратко и ясно." },
                        new { text = $"Вот учебный материал:\n{content}\n\nСделай краткое резюме." }
                    }
                }
            }
        };

        return await SendGeminiRequestAsync(requestBody);
    }
    
    public async Task<string> AskQuestionAsync(string question, string block)
    {
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    role = "user",
                    parts = new[]
                    {
                        new { text = "Ты помощник, отвечай кратко и понятно по теме материала." },
                        new { text = $"Материал:\n{block}\n\nВопрос: {question}" }
                    }
                }
            }
        };

        return await SendGeminiRequestAsync(requestBody);
    }
    

    private async Task<string> SendGeminiRequestAsync(object requestBody)
    {
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Post, geminiUrl);
        request.Headers.Add("x-goog-api-key", apiKey);
        request.Content = content;

        var response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var errorText = await response.Content.ReadAsStringAsync();
            throw new Exception($"Gemini API Error: {response.StatusCode}, {errorText}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);

        var candidates = doc.RootElement.GetProperty("candidates");
        if (candidates.GetArrayLength() == 0)
            throw new Exception("Gemini API Error: Empty candidates in response.");

        return candidates[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();
    }
}
