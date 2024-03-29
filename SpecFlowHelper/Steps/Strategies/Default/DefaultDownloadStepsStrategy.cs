﻿using System.IO;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelper.Integrations;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default download steps strategy.
    /// </summary>
    public class DefaultDownloadStepsStrategy : StepsStrategyBase<DownloadSteps>, IDownloadStepsStrategy
    {
        /// <summary>
        /// When clear the downloads folder.
        /// </summary>
        public void WhenClearTheDownloadsFolder()
        {
            DownloadFolder.DeleteFiles();
        }

        /// <summary>
        /// Then should exists a file with the name in the downloads folder.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void ThenShouldExistsAFileWithTheNameInTheDownloadsFolder(string filename)
        {
            AssertHelper.Attempt(() =>
            {
                StepHelper.Wait("arquivo aparecer na pasta de downloads");
                var files = DownloadFolder.GetFiles(filename);

                return files.Length == 1 && Path.GetFileName(files[0]) == filename;
            });
        }

        /// <summary>
        /// Then should exists files with the extension in the downloads folder.
        /// </summary>
        /// <param name="fileCount">The file count.</param>
        /// <param name="fileExtension">The file extension.</param>
        public void ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder(int fileCount, string fileExtension)
        {
            AssertHelper.Attempt(() =>
            {
                var files = DownloadFolder.GetFiles("*.{0}".With(fileExtension));
                return fileCount == files.Length;
            });
        }
    }
}