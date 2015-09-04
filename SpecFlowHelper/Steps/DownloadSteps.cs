using System.IO;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelper.Integrations;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class DownloadSteps : StepsBase
    {
        [When(@"limpo a pasta de downloads do usuário")]
        public void QuandoLimpoAPastaDeDownloadsDoUsuario()
        {
            DownloadFolder.DeleteFiles();
        }

        [Then(@"deve existir um arquivo com o nome '(.*)' na pasta de downloads")]
        public void EntaoDeveExistirUmArquivoComONomeNaPastaDeDownloads(string filename)
        {
            StepHelper.Attempt(() =>
            {
                StepHelper.Wait("arquivo aparecer na pasta de downloads");
                var files = DownloadFolder.GetFiles(filename);
                Assert.AreEqual(1, files.Length);
                Assert.AreEqual(filename, Path.GetFileName(files[0]), filename);

                return true;
            });
        }

        [Then(@"deve existir (.*) arquivo com a extensão '(.*)' na pasta de downloads")]
        public void EntaoDeveExistirUmArquivoComONomeNaPastaDeDownloads(int fileCount, string fileExtension)
        {
            StepHelper.Attempt(() =>
            {
                var files = DownloadFolder.GetFiles("*.{0}".With(fileExtension));
                Assert.AreEqual(fileCount, files.Length, fileExtension);

                return true;
            });
        }
    }
}
