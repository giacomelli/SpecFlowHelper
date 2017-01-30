using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class InfrastructureSteps : StepsBase
    {
        #region Properties
        private IInfrastructureStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IInfrastructureStepsStrategy, InfrastructureSteps>(this);
            }
        }
        #endregion

        #region Methods
        [When(Locale.WhenClearWebApiCache)]
        public void WhenClearWebApiCache()
        {
            Strategy.WhenClearWebApiCache();
        }

        [When(Locale.WhenReinitializeDBAndServers)]
        public void WhenReinitializeDBAndServers()
        {
            Strategy.WhenReinitializeDBAndServers();
        }

        [When(Locale.WhenReinitializeDBAndServerOneTimeToFeature)]
        public void WhenReinitializeDBAndServerOneTimeToFeature()
        {
            Strategy.WhenReinitializeDBAndServerOneTimeToFeature();
        }
        #endregion
    }
}
