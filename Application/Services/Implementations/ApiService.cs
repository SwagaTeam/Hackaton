using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Application.Services.Abstractions;

namespace Application.Services.Implementations;

public class ApiService : IApiService
{
    private readonly HttpClient httpClient;
    private readonly string apiKey =
        "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";
    public ApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetSummaryAsync(string content)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Ты помогаешь студенту понять учебный материал. Выдели ключевые идеи кратко и ясно." },
                new { role = "user", content = $"Вот учебный материал:\n{content}\n\nСделай краткое резюме." }
            }
        };

        return await SendRequestAsync(requestBody);
    }

    public async Task<string> AskQuestionAsync(string question, string block)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Ты помощник, отвечай кратко и понятно по теме материала." },
                new { role = "user", content = $"Материал:\n{block}\n\nВопрос: {question}" }
            }
        };

        return await SendRequestAsync(requestBody);
    }

    private async Task<string> SendRequestAsync(object requestBody)
    {
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorText = await response.Content.ReadAsStringAsync();
            throw new Exception($"OpenAI API Error: {response.StatusCode}, {errorText}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();
    }
}
