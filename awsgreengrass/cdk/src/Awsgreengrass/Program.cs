using Amazon.CDK;

namespace Awsgreengrass
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            var env = makeEnv(account: "262794326545", region: "us-east-1");

            new AwsgreengrassStack(app, "AwsgreengrassStack", false, new StackProps { Env = env });
            app.Synth();
        }
        static Amazon.CDK.Environment makeEnv(string account, string region)
        {
            return new Amazon.CDK.Environment
            {
                Account = account,
                Region = region
            };
        }
    }
}



