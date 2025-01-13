using System;
using BlackJack.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace BlackJack;
class ApiController
{
    static HttpClient client = new HttpClient();
    public static async Task SendResult(Result result)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://blackjack-backend.holz-edv.de/log", result);
        response.EnsureSuccessStatusCode();
    }

    public static async Task<JsonArray> GetResults()
    {
        JsonArray results = await client.GetFromJsonAsync<JsonArray>("https://blackjack-backend.holz-edv.de/leaderboard?limit=5");
        if(results == null)
        {
            throw new Exception("No results found");
        }
        return results;
    }
}