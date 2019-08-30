using System;
using System.IO;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Helpers;
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

            StepHelper.Log("Executable filename: {0}", exeFileName);
            StepHelper.Log("Log filename: {0}", logFileName);

            var processName = AppConfig.JobsProcessName;

            QuandoEncerroOJob(name);

            StepHelper.Sleep(1000, "aguardando job liberar arquivo de log");
            StepHelper.Log("Deleting log files");
            FileHelper.DeleteFiles(logFileName);

            StepHelper.Wait("Aguardando job....");

            StepHelper.Log("Running job");

            if (string.IsNullOrEmpty(name))
                ProcessHelper.Run(exeFileName, string.Empty, false);
            else
                ProcessHelper.Run(exeFileName, "-job:{0}".With(name), false);

            EntaoExisteOTextoNoLogDoJob(text);
            QuandoEncerroOJob(name);
        }

        [When(@"executo o job e aguardo pelo texto '(.*)' no log")]
        public void QuandoExecutoOJob(string text)
        {
            QuandoExecutoOJob(null, text);
        }

        [When(@"executo o job e aguardo pelo texto '(.*)' na saída")]
        public void QuandoExecutoOJobEAguardoPeloTextoNaSaida(string text)
        {
            if (AppConfig.JobsEnabled)
            {
                var exeFileName = GetExeFileName();

                StepHelper.Log("Executable filename: {0}", exeFileName);

                var processName = AppConfig.JobsProcessName;

                QuandoEncerroOJob(null);

                StepHelper.Wait("Waiting job....");
                StepHelper.Log("Running job");

                ProcessHelperEx.Run(exeFileName, string.Empty, text);

                QuandoEncerroOJob(null);
            }
            else
            {
                StepHelper.Log($"Job disabled: {AppConfig.JobsEnabledInfo}");
            }
        }

        [When(@"executo o job")]
        public void QuandoExecutoOJob()
        {
            if (AppConfig.JobsEnabled)
            {
                var exeFileName = GetExeFileName();

                StepHelper.Log("Executable filename: {0}", exeFileName);

                var processName = AppConfig.JobsProcessName;

                QuandoEncerroOJob(null);

                StepHelper.Wait("Waiting job....");
                StepHelper.Log("Running job");

                ProcessHelperEx.Run(exeFileName, string.Empty);
            }
            else
            {
                StepHelper.Log($"Job disabled: {AppConfig.JobsEnabledInfo}");
            }
        }


        [Then(@"existe o texto '(.*)' no log do job")]
        public void EntaoExisteOTextoNoLogDoJob(string text)
        {
            StepHelper.Log("Waiting for text '{0}' on job's log file", text); ;

            var logFileName = GetLogFileName();

            FileHelper.WaitForFileContentContains(logFileName, text, Convert.ToInt32(AppConfig.ScenarioTimeout.TotalSeconds));
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
            var processName = AppConfig.JobsProcessName;

            if (String.IsNullOrEmpty(name))
                StepHelper.Log("Kiling {0} process", processName);
            else
                StepHelper.Log("Kiling {0} process for job '{1}'", processName, name);

            ProcessHelper.KillAll(processName);
            ProcessHelper.WaitForExit(processName);
        }


        public static string GetLogFileName()
        {
            var logFileName = Path.Combine(GetRootPath(), AppConfig.JobsLogFileName);
            return logFileName;
        }

        public static string GetExeFileName()
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
