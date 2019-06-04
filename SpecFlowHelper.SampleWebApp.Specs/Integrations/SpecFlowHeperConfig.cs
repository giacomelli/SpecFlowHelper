using HelperSharp;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using SpecFlowHelper.Integrations.Browsers;
using SpecFlowHelper.Logging;
using SpecFlowHelper.SampleWebApp.Specs.Integrations.Environments;
using SpecFlowHelper.Steps;
using SpecFlowHelper.Steps.Strategies;
using SpecFlowHelper.Steps.Strategies.jQuery;
using TechTalk.SpecFlow;
using TestSharp;

namespace SpecFlowHelper.SampleWebApp.Specs.Integrations
{
    [Binding]
    public class SpecFlowHeperConfig
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AppConfig.Environment = new SampleContinuousIntegrationEnvironment();
            AppConfig.BrowserKind = BrowserKind.Chrome;
            AppConfig.BrowserDriverFolder = VSProjectHelper.GetProjectFolderPath("SpecFlowHelper.SampleWebApp.Specs") + @"\Drivers";
            AppConfig.Configuration = "Debug";

            AppConfig.WebProjects = new WebProjectConfig[]
            {
                new WebProjectConfig(WebProjectKind.Api, "SpecFlowHelper.SampleWebApi", 8001),
                new WebProjectConfig(WebProjectKind.App, "SpecFlowHelper.SampleWebApp", 8000)
            };

            AppConfig.JobsEnabled = true;
            AppConfig.JobsLogFileName = "SpecFlowHelper.SampleWindowsService-log.txt";
            AppConfig.JobsProcessName = "SpecFlowHelper.SampleWindowsService";
            AppConfig.JobsProjectFolderName = "SpecFlowHelper.SampleWindowsService";

            ExecutionEvents.ElementClicking += (sender, args) =>
            {
                StepHelper.Log("Will click on {0}".With(args.Element.TagName));
            };

            StrategyFactory.Register<IComboboxStepsStrategy, ComboboxSteps>(new jQueryComboboxStepsStrategy());
        }
    }
}
