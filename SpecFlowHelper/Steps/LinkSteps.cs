using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class LinkSteps : StepsBase
    {
        [When(@"clico no link '(.*)'")]
        public void QuandoClicoNoLink(string text)
        {
            StepHelper.Click(By.LinkText(text));
        }
    }
}
