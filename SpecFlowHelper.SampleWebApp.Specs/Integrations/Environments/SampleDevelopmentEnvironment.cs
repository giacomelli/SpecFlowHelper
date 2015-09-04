using SpecFlowHelper.Integrations.Databases;
using SpecFlowHelper.Integrations.Environments;

namespace SpecFlowHelper.SampleWebApp.Specs.Integrations.Environments
{
    public class SampleDevelopmentEnvironment : DevelopmentEnvironment
    {
        public SampleDevelopmentEnvironment()
        {
            AvailableDatabases = new IDatabase[] 
            {
                new SqlServerDatabase("localhost", "Data Source=localhost;Initial Catalog=test;User ID=AppUser;Password=AppUser;MultipleActiveResultSets=True")
            };
        }
    }
}
