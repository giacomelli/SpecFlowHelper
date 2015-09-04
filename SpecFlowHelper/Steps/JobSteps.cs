using System.IO;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using TechTalk.SpecFlow;
using TestSharp;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class JobSteps : StepsBase
    {
        [When(@"executo o job '(.*)' e aguardo pelo texto '(.*)' no log")]
        public void QuandoExecutoOJob(string name, string text)
        {
            var exeFileName = GetExeFileName();
            var logFileName = GetLogFileName();

            var processName = AppConfig.JobsProcessName;

            StepHelper.Log("Kiling {0} process", processName);
            ProcessHelper.KillAll(processName);

            StepHelper.Log("Waiting {0} exit", processName);
            ProcessHelper.WaitForExit(processName);

            StepHelper.Sleep(1000, "aguardando job liberar arquivo de log");
            StepHelper.Log("Deleting log files");
            FileHelper.DeleteFiles(logFileName);

            StepHelper.Log("Running job");
            ProcessHelper.Run(exeFileName, "-job:{0}".With(name), false);

            EntaoExisteOTextoNoLogDoJob(text);
            QuandoEncerroOJob(name);
        }


        [Then(@"existe o texto '(.*)' no log do job")]
        public void EntaoExisteOTextoNoLogDoJob(string text)
        {
            StepHelper.Log("Waiting for text '{0}' on job's log file", text); ;

            var logFileName = GetLogFileName();

            FileHelper.WaitForFileContentContains(logFileName, text, RuntimeEnvironment.Current.WaitMilliseconds * 60);
            ProcessHelper.KillAll(AppConfig.JobsProcessName);

            FileAssert.ContainsContent(text, logFileName);
        }

        [Then(@"não existe o texto '(.*)' no log do job")]
        public void EntaoNaoExisteOTextoNoLogDoJob(string text)
        {
            var logFileName = GetLogFileName();
            ProcessHelper.KillAll(AppConfig.JobsProcessName);

            Assert.IsFalse(FileHelper.ContainsContent(logFileName, text));
        }

        [When(@"encerro o job '(.*)'")]
        public void QuandoEncerroOJob(string name)
        {
            ProcessHelper.KillAll(AppConfig.JobsProcessName);
        }


        private static string GetLogFileName()
        {
            var logFileName = Path.Combine(GetBinPath(), "logs");
            logFileName = Path.Combine(logFileName, AppConfig.JobsLogFileName);
            return logFileName;
        }

        private static string GetExeFileName()
        {
            var exeFileName = Path.Combine(GetConfigPath(), "{0}.exe".With(AppConfig.JobsProcessName));
            return exeFileName;
        }

        private static string GetConfigPath()
        {
            var configPath = Path.Combine(GetBinPath(), AppConfig.Configuration);
            return configPath;
        }

        private static string GetBinPath()
        {
            var binPath = Path.Combine(GetRootPath(), "bin");
            return binPath;
        }

        private static string GetRootPath()
        {
            var backgroundWorkerPath = VSProjectHelper.GetProjectFolderPath(AppConfig.JobsProjectFolderName);
            return backgroundWorkerPath;
        }
    }
}
