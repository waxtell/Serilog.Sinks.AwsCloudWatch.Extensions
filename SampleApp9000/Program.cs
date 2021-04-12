using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.CloudWatchLogs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleApp9000.Extensions;
using Serilog;
using Serilog.Sinks.AwsCloudWatch.Extensions.Extensions;

namespace SampleApp9000
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                            .Build();

            await host
                .RunConsoleAsync<IServiceProvider>
                (
                    async serviceProvider =>
                    {
                        serviceProvider
                            .GetService<ILogger<Program>>()
                            .LogInformation("Hello AwsCloudWatch!");
                        
                        Log
                            .CloseAndFlush();

                        await 
                            Task.CompletedTask;
                    }
                );
        }

        public static IHostBuilder CreateHostBuilder(string[] _) =>
            new HostBuilder()
                .ConfigureAppConfiguration
                (
                    (_, config) =>
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
                        var awsOptions = context.Configuration.GetAWSOptions();

                        awsOptions.Credentials = context.Configuration.GetAwsCredentials();
                        collection.AddDefaultAWSOptions(awsOptions);
                        collection.AddAWSService<IAmazonCloudWatchLogs>();

                        CloudWatchLogsClientExtensions.ClientFactory = _ => awsOptions.CreateServiceClient<IAmazonCloudWatchLogs>();
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
