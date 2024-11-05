using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using Spectre.Console.Builder;

SpectreConsoleHostBuilder builder = SpectreConsoleHost.CreateBuilder<DefaultCommand>(args);

await builder.Build().RunAsync();

public class DefaultCommand(ILogger<DefaultCommand> logger) : AsyncCommand
{
    public override Task<int> ExecuteAsync(CommandContext context)
    {
        logger.LogInformation("Default command executed");
        return Task.FromResult(0);
    }
}