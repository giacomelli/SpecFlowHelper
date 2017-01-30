using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Badge steps.
    /// </summary>
    [Binding]
    public class BadgeSteps : StepsBase
    {
        #region Properties
        private IBadgeStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IBadgeStepsStrategy, BadgeSteps>(this);
            }
        }
        #endregion

        #region Methods
        [Then(Locale.ThenShouldShowTheBadgeWithTheText)]
        public void ThenShouldShowTheBadgeWithTheText(string text)
        {
            Strategy.ThenShouldShowTheBadgeWithTheText(text);
        }
        #endregion
    }
}
