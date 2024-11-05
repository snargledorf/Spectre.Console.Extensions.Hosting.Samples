using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using Spectre.Console.Builder;

namespace DotNetFramework48
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SpectreConsoleHostBuilder builder = SpectreConsoleHost.CreateBuilder<DotNetFramework48Command>(args);

            builder.Build().Run();
        }
    }
    
    public class DotNetFramework48Command : AsyncCommand
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ILogger<DotNetFramework48Command> _logger;

        public DotNetFramework48Command(IHostApplicationLifetime applicationLifetime, ILogger<DotNetFramework48Command> logger)
        {
            _applicationLifetime = applicationLifetime;
            _logger = logger;
        }

        public override async Task<int> ExecuteAsync(CommandContext context)
        {
            _logger.LogInformation("Waiting for 10 seconds or application stop request");
            
            await Task.Delay(TimeSpan.FromSeconds(10), _applicationLifetime.ApplicationStopping);

            return 0;
        }
    }
}