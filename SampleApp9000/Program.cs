using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp9000.Extensions;
using Serilog;

namespace SampleApp9000
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await
                CreateHostBuilder(args)
                    .RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] _) =>
            new HostBuilder()
                .ConfigureAppConfiguration
                (
                    (hostContext, config) =>
                    {
                        config
                            .SetBasePath(Directory.GetCurrentDirectory())
                            // ReSharper disable once StringLiteralTypo
                            .AddJsonFile("appsettings.json", optional: true);
                    }
                )
                .ConfigureServices
                (
                    (context, collection) =>
                    {
                        collection
                            .AddHostedService<SampleAppHostedService>();

                        collection
                            .AddDefaultAWSOptions();
                    }
                )
                .UseSerilog
                (
                    (hostingContext, loggerConfiguration) =>
                    {
                        loggerConfiguration
                            .ReadFrom
                            .Configuration(hostingContext.Configuration)
                            .Enrich
                            .FromLogContext();
                    }
                );
    }
}
