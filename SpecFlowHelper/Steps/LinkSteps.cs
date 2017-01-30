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

        [When(@"clico no link que contém o texto '(.*)'")]
        public void QuandoClicoNoLinkQueContemOTexto(string text)
        {
            StepHelper.Click(By.XPath("//a[contains(., '{0}')]".With(text)));
        }
    }
}
