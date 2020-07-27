using System;
using Amazon;
using Amazon.CloudWatchLogs;

namespace Serilog.Sinks.AwsCloudWatch.Extensions.Extensions
{
    public class CloudWatchLogsClientExtensions
    {
        public static Func<RegionEndpoint, IAmazonCloudWatchLogs> ClientFactory { get; set; } = endpoint => new AmazonCloudWatchLogsClient(endpoint);
    }
}
