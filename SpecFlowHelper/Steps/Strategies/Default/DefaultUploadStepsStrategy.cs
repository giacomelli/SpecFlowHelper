using System.IO;
using HelperSharp;
using OpenQA.Selenium;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default upload steps strategy.
    /// </summary>
    public class DefaultUploadStepsStrategy : StepsStrategyBase<UploadSteps>, IUploadStepsStrategy
    {
        /// <summary>
        /// When upload the file.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        public virtual void WhenUploadTheFile(string relativeFileName)
        {
            WhenUploadTheFile(relativeFileName, By.XPath("//input[@type='file']"));
        }

        /// <summary>
        /// When the upload in field the file.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="relativeFileName">The relative filename.</param>
        public virtual void WhenUploadInTheFile(string field, string relativeFileName)
        {
            var by = By.XPath("//input[@type='file' and @id='{0}']|//input[@type='file' and contains(@class, '{0}')]".With(field));
            WhenUploadTheFile(relativeFileName, by);
        }

        private void WhenUploadTheFile(string fileName, By by)
        {
            StepHelper.WaitElementIsPresent(by);
            var element = CurrentSteps.Driver.FindElement(by);

            var fullPath = Path.Combine(AppConfig.UploadFilesFolder, fileName);
            StepHelper.Log("Utilizando o arquivo '{0}' para o upload.", fullPath);

            if (!File.Exists(fullPath))
            {
                var msg = "Arquivo que seria utilizado para upload não existe: {0}".With(fullPath);
                StepHelper.Log(msg);

                throw new FileNotFoundException(msg, fullPath);
            }

            StepHelper.Wait("aguardando para iniciar o upload do arquivo");
            StepHelper.WaitElementIsNotVisible(By.CssSelector(".block-ui-container"), 20);

            StepHelper.Attempt(() =>
            {
                element.SendKeys(fullPath);
                return true;
            });

            StepHelper.Wait("aguardando o upload do arquivo");
            StepHelper.WaitElementIsNotVisible(By.CssSelector(".block-ui-container"), 20);
            StepHelper.Wait("aguardando block ui");
        }

        /// <summary>
        /// When the upload the file in downloads folder.
        /// </summary>
        /// <param name="relativeFileName">The relative filename.</param>
        public virtual void WhenUploadTheFileInDownloadsFolder(string relativeFileName)
        {
            StepHelper.Attempt(() =>
            {
                WhenUploadTheFile(DownloadFolder.GetFile(relativeFileName));

                return true;
            });
        }
    }
}
