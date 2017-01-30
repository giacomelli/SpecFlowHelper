namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for download steps strategies.
    /// </summary>
    public interface IDownloadStepsStrategy : IStepsStrategy<DownloadSteps>
    {
        /// <summary>
        /// When clear the downloads folder.
        /// </summary>
        void WhenClearTheDownloadsFolder();

        /// <summary>
        /// Then should exists a file with the name in the downloads folder.
        /// </summary>
        /// <param name="filename">The filename.</param>
        void ThenShouldExistsAFileWithTheNameInTheDownloadsFolder(string filename);

        /// <summary>
        /// Then should exists files with the extension in the downloads folder.
        /// </summary>
        /// <param name="fileCount">The file count.</param>
        /// <param name="fileExtension">The file extension.</param>
        void ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder(int fileCount, string fileExtension);
    }
}
