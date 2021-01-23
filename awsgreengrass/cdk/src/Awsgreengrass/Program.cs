using Amazon.CDK;

namespace Awsgreengrass
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new AwsgreengrassStack(app, "AwsgreengrassStack");

            app.Synth();
        }
    }
}
