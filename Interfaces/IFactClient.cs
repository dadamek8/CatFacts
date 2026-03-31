using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Interfaces
{
    public interface IFactClient
    {
        Task<FactResponse> GetFactAsync(CancellationToken cancellationToken = default);
    }
}
