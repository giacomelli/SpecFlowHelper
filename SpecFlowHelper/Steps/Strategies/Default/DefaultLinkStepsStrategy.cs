using HelperSharp;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default link steps strategy.
    /// </summary>
    public class DefaultLinkStepsStrategy : StepsStrategyBase<LinkSteps>, ILinkStepsStrategy
    {
        public virtual void WhenClickTheLink(string text)
        {
            StepHelper.Click(By.LinkText(text));
        }

        public virtual void WhenClickTheLinkContainsText(string text)
        {
            StepHelper.Click(By.XPath("//a[contains(., '{0}')]".With(text)));
        }
    }
}