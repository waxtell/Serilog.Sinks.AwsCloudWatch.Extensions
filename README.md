# Serilog.Sinks.AwsCloudWatch.Extensions
Configuration helper for the [AwsCloudWatch Serilog Sink](https://github.com/Cimpress-MCP/serilog-sinks-awscloudwatch)

While all of the CloudWatchSinkOptions properties are configurable, only the group name and region are required, as demonstrated below:

  ```cs
    "WriteTo": [
      {
        "Name": "CloudWatch",
        "Args": {
          "logGroupName": "SampleApp9000",
          "regionEndpointSystemName": "us-east-2"
        }
      }
    ]
  ```

Please visit [Cimpress-MCP/serilog-sinks-awscloudwatch](https://github.com/Cimpress-MCP/serilog-sinks-awscloudwatch) for additional configuration details.