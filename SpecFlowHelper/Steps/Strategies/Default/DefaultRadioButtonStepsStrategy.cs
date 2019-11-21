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
            var by = GetBy(radioButton);
            AssertHelper.AssertIsNotChecked(by);
            StepHelper.Click(by);
        }
        
        public virtual void ThenTheRadioButtonShouldBeReadOnly(string radioButton)
        {
            var by = GetBy(radioButton);

            StepHelper.Attempt(() =>
            {
                AssertHelper.AssertIsDisabled(by);
                return true;
            });
        }

        By GetBy(string radioButton) => By.XPath("//label[contains(., '{0}') and contains(@class, 'radio')]|//input[@title='{0}' and @type='radio']|//label[@class='ng-binding' and text()='{0}']/following-sibling::label|//label[contains(., '{0}')]/span[contains(@class, 'checklabel')]|//input[@data-path='{0}' and @type='radio']|//input[@data-path='{0}' and @type='checkbox']".With(radioButton));
    }
}