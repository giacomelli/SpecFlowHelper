using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Buttons 
    /// steps.
    /// </summary>
    [Binding]
    public sealed class ButtonSteps : StepsBase
    {
        #region Properties
        private IButtonStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IButtonStepsStrategy, ButtonSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When click in the button.
        /// </summary>
        /// <param name="label">The button label.</param>
        [When(Locale.WhenClickInTheButton)]
        [Then(Locale.WhenClickInTheButton)]
        public void WhenClickInTheButton(string label)
        {
            Strategy.WhenClickInTheButton(label);
        }
        #endregion
    }
}
