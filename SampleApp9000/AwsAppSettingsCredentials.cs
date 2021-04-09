using Amazon.Runtime;

namespace SampleApp9000
{
    public class AwsAppSettingsCredentials : AWSCredentials
    {
        public string AccessKeyId { get; set; }
        public string SecretKey { get; set; }

        public override ImmutableCredentials GetCredentials()
        {
            return
                new ImmutableCredentials
                (
                    AccessKeyId,
                    SecretKey,
                    null
                );
        }
    }
}
