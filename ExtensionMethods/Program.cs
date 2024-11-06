using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using Spectre.Console.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSpectreConsole<DefaultCommand>(args, configurator =>
{
    configurator.AddCommand<ExampleCommand>("example");
});
            
await builder.Build().RunAsync();

public class DefaultCommand(ILogger<DefaultCommand> logger) : AsyncCommand
{
    public override Task<int> ExecuteAsync(CommandContext context)
    {
        logger.LogInformation("Default command executed");
        return Task.FromResult(0);
    }
}

public class ExampleCommand(ILogger<ExampleCommand> logger) : AsyncCommand
{
    public override Task<int> ExecuteAsync(CommandContext context)
    {
        logger.LogInformation("Example command executed");
        return Task.FromResult(0);
    }
}