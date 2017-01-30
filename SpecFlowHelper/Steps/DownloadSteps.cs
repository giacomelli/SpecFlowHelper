using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class DownloadSteps : StepsBase
    {
        #region Properties
        private IDownloadStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IDownloadStepsStrategy, DownloadSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When clear the downloads folder.
        /// </summary>
        [When(Locale.WhenClearTheDownloadsFolder)]
        public void WhenClearTheDownloadsFolder()
        {
            Strategy.WhenClearTheDownloadsFolder();
        }

        /// <summary>
        /// Then should exists a file with the name in the downloads folder.
        /// </summary>
        /// <param name="filename">The filename.</param>
        [Then(Locale.ThenShouldExistsAFileWithTheNameInTheDownloadsFolder)]
        public void ThenShouldExistsAFileWithTheNameInTheDownloadsFolder(string filename)
        {
            Strategy.ThenShouldExistsAFileWithTheNameInTheDownloadsFolder(filename);
        }

        /// <summary>
        /// Then should exists files with the extension in the downloads folder.
        /// </summary>
        /// <param name="fileCount">The file count.</param>
        /// <param name="fileExtension">The file extension.</param>
        [Then(Locale.ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder)]
        public void ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder(int fileCount, string fileExtension)
        {
            Strategy.ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder(fileCount, fileExtension);
        }
        #endregion
    }
}
