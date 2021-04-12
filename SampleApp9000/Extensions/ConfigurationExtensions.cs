using Microsoft.Extensions.Configuration;

namespace SampleApp9000.Extensions
{
    public static class ConfigurationExtensions
    {
        public static AwsAppSettingsCredentials GetAwsCredentials(this IConfiguration configuration, string configKey = nameof(AwsAppSettingsCredentials))
        {
            return
                configuration
                    .GetSection(configKey)
                    .Get<AwsAppSettingsCredentials>();
        }
    }
}
