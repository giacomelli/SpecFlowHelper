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
        private IBrowserStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IBrowserStepsStrategy, BrowserSteps>(this);
            }
        }

        [When(Locale.WhenConfirmTheAlert)]
        public void WhenConfirmTheAlert()
        {
            Strategy.WhenConfirmTheAlert();
        }
    }
}
