using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class ToastSteps : StepsBase
    {
        #region Properties
        private IToastStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IToastStepsStrategy, ToastSteps>(this);
            }
        }
        #endregion

        [Then(@"deve exibir o toast '(.*)'")]
        public void ThenShouldShowTheToast(string message)
        {
            Strategy.ThenShouldShowTheToast(message);
        }

        [Then(@"fecho o toast")]
        public void ThenCloseTheToast()
        {
            Strategy.ThenCloseTheToast();
        }
    }
}
