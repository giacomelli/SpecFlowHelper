using HelperSharp;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default checkbox steps strategy.
    /// </summary>
    public class DefaultCheckboxStepsStrategy : StepsStrategyBase<CheckboxSteps>, ICheckboxStepsStrategy
    {
        /// <summary>
        /// When check the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        public virtual void WhenCheckTheCheckbox(string checkbox)
        {
            var by = By.XPath("//label[contains(., '{0}') and contains(@class, 'btn')]|//input[@title='{0}' and @type='checkbox']|//label[@class='ng-binding' and text()='{0}']/following-sibling::label".With(checkbox));
            AssertHelper.AssertIsNotChecked(by);
            StepHelper.Click(by);
        }

        /// <summary>
        /// Whens uncheck the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        public virtual void WhenUncheckTheCheckbox(string checkbox)
        {
            var by = By.CssSelector("input[title='{0}'][type='checkbox']".With(checkbox));
            AssertHelper.AssertIsChecked(by);
            StepHelper.Click(by);
        }
    }
}