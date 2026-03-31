using ZadanieRekrutacyjne.Interfaces;

namespace ZadanieRekrutacyjne.Services
{
    public sealed class FactService
    {
        private readonly IFactClient _factClient;
        private readonly IFactFileWriter _fileWriter;

        public FactService(IFactClient factClient, IFactFileWriter fileWriter)
        {
            _factClient = factClient;
            _fileWriter = fileWriter;
        }

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var fact = await _factClient.GetFactAsync();
                await _fileWriter.AppendAsync(fact.Fact, fact.Length, cancellationToken);

                Console.WriteLine();
                Console.WriteLine($"Fact: {fact.Fact} | Length: {fact.Length}");
                Console.WriteLine("New fact added and file saved :)");
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to fetch fact");
            }

        }

        public static bool AskToContinue()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Would you like to add another fact to the file? (y/n): ");

                var input = Console.ReadLine()?.Trim().ToLower();

                if (input == "y")
                    return true;

                if (input == "n")
                    return false;

                Console.WriteLine("Please type y (add another fact) or n (close the app)");
            }
        }
    }
}