namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for upload steps strategies.
    /// </summary>
    public interface IUploadStepsStrategy : IStepsStrategy<UploadSteps>
    {
        /// <summary>
        /// When upload the file.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        void WhenUploadTheFile(string relativeFileName);

        /// <summary>
        /// When the upload in field the file.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="relativeFileName">The relative filename.</param>
        void WhenUploadInTheFile(string field, string relativeFileName);

        /// <summary>
        /// When upload the file in downloads folder.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        void WhenUploadTheFileInDownloadsFolder(string relativeFileName);
    }
}
