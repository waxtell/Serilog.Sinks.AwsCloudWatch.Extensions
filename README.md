# Serilog.Sinks.AwsCloudWatch.Extensions ![Build](https://github.com/waxtell/Serilog.Sinks.AwsCloudWatch.Extensions/workflows/Build/badge.svg)![Publish to nuget](https://github.com/waxtell/Serilog.Sinks.AwsCloudWatch.Extensions/workflows/Publish%20to%20nuget/badge.svg?branch=master)
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