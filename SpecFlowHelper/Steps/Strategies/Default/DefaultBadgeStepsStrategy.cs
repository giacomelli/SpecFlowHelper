using OpenQA.Selenium;
namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default badge steps strategy.
    /// </summary>
    public class DefaultBadgeStepsStrategy : StepsStrategyBase<BadgeSteps>, IBadgeStepsStrategy
    {
        /// <summary>
        /// Then should show the badge with the text.
        /// </summary>
        /// <param name="text"></param>
        public virtual void ThenShouldShowTheBadgeWithTheText(string text)
        {
            var by = By.CssSelector(".badge");

            AssertHelper.AssertAnyTextsAreEqual(text, by);
        }
    }
}