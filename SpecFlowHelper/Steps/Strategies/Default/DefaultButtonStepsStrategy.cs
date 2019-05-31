using HelperSharp;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default button steps strategy.
    /// </summary>
    public class DefaultButtonStepsStrategy : StepsStrategyBase<ButtonSteps>, IButtonStepsStrategy
    {
        /// <summary>
        /// When click in the button.
        /// </summary>
        /// <param name="label">The button label.</param>
        public virtual void WhenClickInTheButton(string label)
        {
            var xpath = "//a[text()='{0}']|//input[@value='{0}' and @type='submit']|//input[@value='{0}' and @type='button']|//button[text()='{0}']|//button[contains(text(),'{0}')]|//button[contains(.,'{0}')]|//span[contains(.,'{0}')]|//a[contains(., '{0}') and contains(@class, 'btn')]|//button[@id='{0}']".With(label);
            var by = By.XPath(xpath);

            StepHelper.MoveToElement(by);
            StepHelper.Click(by);
        }
    }
}