using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Configuration
{
    public interface IBaseUrlSolver
    {
        string Solve(ScenarioContext context, IWebDriver driver);
    }
}
