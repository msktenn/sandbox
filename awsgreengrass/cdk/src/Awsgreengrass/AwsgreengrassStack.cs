using Amazon.CDK;
using Amazon.CDK.AWS.EC2;

namespace Awsgreengrass
{
    public class AwsgreengrassStack : Stack
    {
        internal AwsgreengrassStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            Vpc vpc = new Vpc(this, "VPC");
        }
        internal AwsgreengrassStack(Construct scope, string id, bool teardown, IStackProps props = null) : base(scope, id, props)
        {
            if (!teardown)
            {
                SetupStack();
            }
        }

        void SetupStack()
        {
            Vpc vpc = new Vpc(this, "VPC");
        }
    }
}
