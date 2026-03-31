using System.Text;
using ZadanieRekrutacyjne.Interfaces;
using System.IO;

namespace ZadanieRekrutacyjne.FileSave
{
    public sealed class FactFileWriter : IFactFileWriter
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "facts.txt");

        public async Task AppendAsync(string fact, int length, CancellationToken cancellationToken = default)
        {
            var line = $"Fact: {fact} | Length: {length}";
            await File.AppendAllTextAsync(_filePath, line + Environment.NewLine, Encoding.UTF8, cancellationToken);
        }
    }
}
