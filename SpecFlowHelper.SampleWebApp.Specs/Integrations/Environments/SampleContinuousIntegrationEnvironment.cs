using System.IO;
using HelperSharp;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using SpecFlowHelper.Integrations.Databases;
using SpecFlowHelper.Integrations.Environments;
using TestSharp;

namespace SpecFlowHelper.SampleWebApp.Specs.Integrations.Environments
{
    public class SampleContinuousIntegrationEnvironment : ContinousIntegrationEnvironment
    {
        public override void Initialize()
        {
            base.Initialize();

            ExecutionEvents.DatabaseInitialized += (sender, args) =>
            {
                var webApiConfigFilename = Path.Combine(VSProjectHelper.GetProjectFolderPath(AppConfig.WebApiProjectFolderName), "Web.config");
                var content = File.ReadAllText(webApiConfigFilename);
                content = content.Replace(
                    "connectionString=\"Data Source=localhost;Initial Catalog=Test;User ID=AppUser;Password=AppUser;MultipleActiveResultSets=True\"",
                    "connectionString=\"{0}\"".With(Database.Current.ConnectionString));

                File.WriteAllText(webApiConfigFilename, content);
            };
        }

        public SampleContinuousIntegrationEnvironment()
        {
            AvailableDatabases = new IDatabase[] 
            {
                new SqlServerDatabase("server1", "Data Source=db1;Initial Catalog=Test;User ID=AppUser;Password=AppUser;MultipleActiveResultSets=True"),
                new SqlServerDatabase("server2", "Data Source=db2;Initial Catalog=Test;User ID=AppUser;Password=AppUser;MultipleActiveResultSets=True")
            };
        }
    }
}
