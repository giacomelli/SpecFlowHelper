using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class UploadSteps : StepsBase
    {
        #region Properties
        private IUploadStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IUploadStepsStrategy, UploadSteps>(this);
            }
        }
        #endregion

        #region Methods
        [When(@"faço upload do arquivo '(.*)'")]
        public void WhenUploadTheFile(string relativeFileName)
        {
            Strategy.WhenUploadTheFile(relativeFileName);
        }

        [When(@"faço upload no '(.*)' do arquivo '(.*)'")]
        public void WhenUploadInTheFile(string field, string relativeFileName)
        {
            Strategy.WhenUploadInTheFile(field, relativeFileName);
        }

        [When(@"faço upload do arquivo '(.*)' que está na pasta de downloads")]
        public void WhenUploadTheFileInDownloadsFolder(string relativeFileName)
        {
            Strategy.WhenUploadTheFileInDownloadsFolder(relativeFileName);
        }
        #endregion
    }
}
