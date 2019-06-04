using System;
using OpenQA.Selenium;
using SpecFlowHelper.Steps;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Configuration
{
    public class DefaultBaseUrlSolver : IBaseUrlSolver
    {
        public string Solve(ScenarioContext context, IWebDriver driver)
        {
            var webProjects = AppConfig.WebProjects.WebApps();

            if (webProjects.Length == 0)
                throw new InvalidOperationException("There is no web project configured on AppConfig.WebProjects.");

            if (webProjects.Length > 1)
                StepHelper.Log("There is more than one web app project configured at AppConfig.BaseUrl, but you is still using the DefaultBaseUrlSolver. Maybe will need to use something like TagMapBaseUrlSolver.");

            return webProjects[0].BaseUrl;
        }
    }
}
