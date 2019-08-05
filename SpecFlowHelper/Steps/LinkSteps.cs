using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class LinkSteps : StepsBase
    {
        private ILinkStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<ILinkStepsStrategy, LinkSteps>(this);
            }
        }

        [When(@"clico no link '(.*)'")]
        public void QuandoClicoNoLink(string text)
        {
            Strategy.WhenClickTheLink(text);
        }

        [When(@"clico no link que contém o texto '(.*)'")]
        public void QuandoClicoNoLinkQueContemOTexto(string text)
        {
            Strategy.WhenClickTheLinkContainsText(text);
        }
    }
}
