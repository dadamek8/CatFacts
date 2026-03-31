using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZadanieRekrutacyjne.Clients;
using ZadanieRekrutacyjne.FileSave;
using ZadanieRekrutacyjne.Interfaces;
using ZadanieRekrutacyjne.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<IFactClient, FactClient>(client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja/");
});

builder.Services.AddSingleton<IFactFileWriter, FactFileWriter>();
builder.Services.AddTransient<FactService>();

var host = builder.Build();

using var scope = host.Services.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<FactService>();

bool shouldContinue = true;

while (shouldContinue)
{
    await service.RunAsync();

    shouldContinue = FactService.AskToContinue();
}