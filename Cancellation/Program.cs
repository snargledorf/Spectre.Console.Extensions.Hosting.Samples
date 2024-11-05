using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using Spectre.Console.Builder;

SpectreConsoleHostBuilder builder = SpectreConsoleHost.CreateBuilder(args);

builder.Configurator.AddCommand<CommandThatWaitsForCancellation>("waitforcancellation");

await builder.Build().RunAsync();

public class CommandThatWaitsForCancellation(IHostApplicationLifetime applicationLifetime, ILogger<CommandThatWaitsForCancellation> logger) : AsyncCommand
{
    private readonly SemaphoreSlim _semaphore = new(0, 1);
    
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        logger.LogInformation("Waiting for application stop request");
        await _semaphore.WaitAsync(applicationLifetime.ApplicationStopping);

        return 0;
    }
}