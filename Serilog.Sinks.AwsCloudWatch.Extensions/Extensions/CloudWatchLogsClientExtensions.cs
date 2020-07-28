using System;
using Amazon;
using Amazon.CloudWatchLogs;

namespace Serilog.Sinks.AwsCloudWatch.Extensions.Extensions
{
    public class CloudWatchLogsClientExtensions
    {
        /// <summary>
        /// By default, the logger creates an instance of the AmazonCloudWatchLogsClient using only the region endpoint.
        /// If you need to control the creation of the aforesaid client, simply set the ClientFactory to your own custom
        /// client factory.  Unfortunately the code does not have access to any sort of dependency resolver so you will
        /// have to set the factory explicitly.
        /// </summary>
        /// <example>
        /// <code>
        /// var awsOptions = _configuration.GetAWSOptions();
        /// awsOptions.Credentials = new BasicAWSCredentials(_configuration["AWS_ACCESS_KEY_ID"], _configuration["AWS_SECRET_ACCESS_KEY"]);
        /// collection.AddDefaultAWSOptions(awsOptions);
        /// CloudWatchLogsClientExtensions.ClientFactory = _ => awsOptions.CreateServiceClient<IAmazonCloudWatchLogs>();
        /// </code>
        /// </example> 
        public static Func<RegionEndpoint, IAmazonCloudWatchLogs> ClientFactory { get; set; } = endpoint => new AmazonCloudWatchLogsClient(endpoint);
    }
}
