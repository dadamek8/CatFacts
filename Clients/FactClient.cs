using System.Net.Http.Json;
using ZadanieRekrutacyjne.Interfaces;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Clients
{
    public sealed class FactClient : IFactClient
    {
        private readonly HttpClient _httpClient;

        public FactClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FactResponse> GetFactAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetFromJsonAsync<FactResponse>(
                "fact",
                cancellationToken);

            return response ?? throw new InvalidOperationException("API returned empty response.");
        }
    }
}
