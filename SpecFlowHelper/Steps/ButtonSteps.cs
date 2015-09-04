using HelperSharp;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class ButtonSteps : StepsBase
    {
        [When(@"clico no botão '(.*)'")]
        [Then(@"clico no botão '(.*)'")]
        public virtual void QuandoClicoNoBotao(string label)
        {
            var xpath = "//a[text()='{0}']|//input[@value='{0}' and @type='submit']|//button[text()='{0}']|//button[contains(text(),'{0}')]|//button[contains(.,'{0}')]|//span[contains(.,'{0}')]|//a[contains(., '{0}') and contains(@class, 'btn')]".With(label);
            var by = By.XPath(xpath);

            StepHelper.MoveToElement(by);
            StepHelper.Click(by);
        }
    }
}
