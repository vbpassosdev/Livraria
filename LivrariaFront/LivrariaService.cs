using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class LivrariaService
{
    private readonly HttpClient _httpClient;

    public LivrariaService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("LivrariaApi");
    }

    public async Task<List<Livro>> GetLivrosAsync()
    {
        var response = await _httpClient.GetAsync("/livros");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Livro>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
