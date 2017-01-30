using HelperSharp;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default radiobutton steps strategy.
    /// </summary>
    public class DefaultRadioButtonStepsStrategy : StepsStrategyBase<RadioButtonSteps>, IRadioButtonStepsStrategy
    {
        public virtual void WhenCheckTheRadioButton(string radioButton)
        {
            var by = By.XPath("//label[contains(., '{0}') and contains(@class, 'radio')]|//input[@title='{0}' and @type='radio']|//label[@class='ng-binding' and text()='{0}']/following-sibling::label".With(radioButton));
            AssertHelper.AssertIsNotChecked(by);
            StepHelper.Click(by);
        }
    }
}