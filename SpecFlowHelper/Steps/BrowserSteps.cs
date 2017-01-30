using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Browser steps.
    /// </summary>
    [Binding]
    public class BrowserSteps : StepsBase
    {
        #region Properties
        private IBrowserStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IBrowserStepsStrategy, BrowserSteps>(this);
            }
        }
        #endregion

        #region Methods
        [When(Locale.WhenConfirmTheAlert)]
        public void WhenConfirmTheAlert()
        {
            Strategy.WhenConfirmTheAlert();
        }
        #endregion
    }
}
