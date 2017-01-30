using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Upload steps.
    /// </summary>
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
        /// <summary>
        /// When upload the file.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        [When(@"faço upload do arquivo '(.*)'")]
        public void WhenUploadTheFile(string relativeFileName)
        {
            Strategy.WhenUploadTheFile(relativeFileName);
        }

        /// <summary>
        /// When the upload in field the file.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="relativeFileName">The relative filename.</param>
        [When(@"faço upload no '(.*)' do arquivo '(.*)'")]
        public void WhenUploadInTheFile(string field, string relativeFileName)
        {
            Strategy.WhenUploadInTheFile(field, relativeFileName);
        }

        /// <summary>
        /// When upload the file in downloads folder.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        [When(@"faço upload do arquivo '(.*)' que está na pasta de downloads")]
        public void WhenUploadTheFileInDownloadsFolder(string relativeFileName)
        {
            Strategy.WhenUploadTheFileInDownloadsFolder(relativeFileName);
        }
        #endregion
    }
}
