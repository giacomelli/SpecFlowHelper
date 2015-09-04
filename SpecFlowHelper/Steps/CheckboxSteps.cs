using HelperSharp;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class CheckboxSteps : StepsBase
    {
        [When(@"marco a checkbox '(.*)'")]
        public void QuandoMarcoACheckbox(string checkboxLabel)
        {
            var by = By.XPath("//label[contains(., '{0}') and contains(@class, 'btn')]|//input[@title='{0}' and @type='checkbox']|//label[@class='ng-binding' and text()='{0}']/following-sibling::label".With(checkboxLabel));
            AssertHelper.AssertIsNotChecked(by);
            StepHelper.Click(by);
        }

        [When(@"desmarco a checkbox '(.*)'")]
        public void QuandoDesmarcoACheckbox(string checkboxLabel)
        {
            var by = By.CssSelector("input[title='{0}'][type='checkbox']".With(checkboxLabel));
            AssertHelper.AssertIsChecked(by);
            StepHelper.Click(by);
        }
    }
}
