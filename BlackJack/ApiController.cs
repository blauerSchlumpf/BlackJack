using System;
using BlackJack.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace BlackJack;
static class ApiController
{
    static HttpClient client = new HttpClient();
    static readonly int maxStats = 5;
    public static async Task SendResult(Result result)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://blackjack-backend.holz-edv.de/log", result);
        response.EnsureSuccessStatusCode();
    }

    public static async Task<JsonArray?> GetResults()
    {
        try
        {
            JsonArray? results = await client.GetFromJsonAsync<JsonArray>("https://blackjack-backend.holz-edv.de/leaderboard?limit=" + maxStats);
            if (results == null)
            {
                throw new Exception("No results found");
            }
            return results;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            return null;
        }
    }
}