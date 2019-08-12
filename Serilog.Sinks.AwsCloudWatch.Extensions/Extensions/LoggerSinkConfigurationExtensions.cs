using System;
using Amazon;
using Amazon.CloudWatchLogs;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Compact;
using Serilog.Sinks.AwsCloudWatch;

// ReSharper disable once IdentifierTypo
// ReSharper disable once CheckNamespace
namespace Serilog
{
    // ReSharper disable once UnusedMember.Global
    public static class LoggerSinkConfigurationExtensions
    {
        // ReSharper disable once UnusedMember.Global
        public static LoggerConfiguration CloudWatch
            (
                this LoggerSinkConfiguration sinkConfiguration,
                string logGroupName,
                string regionEndpointSystemName,
                bool createLogGroup = true,
                LogEventLevel restrictedToMinimumLevel = LogEventLevel.Information,
                int batchSizeLimit = 100,
                int queueSizeLimit = 10000,
                byte retryAttempts = 5,
                TimeSpan? period = null,
                string logStreamNameProviderFqn = null,
                string textFormatterFqn = null
            )
        {
            ILogStreamNameProvider GetLogStreamNameProvider()
            {
                if (string.IsNullOrEmpty(logStreamNameProviderFqn))
                {
                    return new DefaultLogStreamProvider();
                }

                var logStreamNameProviderType = Type.GetType(logStreamNameProviderFqn);

                return
                    (ILogStreamNameProvider)
                        Activator
                            .CreateInstance(logStreamNameProviderType ?? throw new ArgumentNullException(nameof(logStreamNameProviderType)));
            }

            ITextFormatter GetTextFormatter()
            {
                if (string.IsNullOrEmpty(textFormatterFqn))
                {
                    return new CompactJsonFormatter();
                }

                var textFormatterType = Type.GetType(textFormatterFqn);

                return
                    (ITextFormatter)
                        Activator
                            .CreateInstance(textFormatterType ?? throw new ArgumentNullException(nameof(textFormatterType)));
            }

            var options = new CloudWatchSinkOptions
            {
                LogGroupName = logGroupName,
                TextFormatter = GetTextFormatter(),
                MinimumLogEventLevel = restrictedToMinimumLevel,
                BatchSizeLimit = batchSizeLimit,
                QueueSizeLimit = queueSizeLimit,
                Period = period ?? CloudWatchSinkOptions.DefaultPeriod,
                CreateLogGroup = createLogGroup,
                LogStreamNameProvider = GetLogStreamNameProvider(),
                RetryAttempts = retryAttempts
            };

            var endPoint = RegionEndpoint.GetBySystemName(regionEndpointSystemName);
            var client = new AmazonCloudWatchLogsClient(endPoint);

            return 
                sinkConfiguration
                    .Sink
                    (
                        new CloudWatchLogSink(client, options), 
                        options.MinimumLogEventLevel
                    );
        }
    }
}