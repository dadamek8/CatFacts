namespace ZadanieRekrutacyjne.Interfaces
{
    public interface IFactFileWriter
    {
        Task AppendAsync(string fact, int length, CancellationToken cancellationToken = default);
    }
}
