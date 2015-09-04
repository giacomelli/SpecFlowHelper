using System;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using TechTalk.SpecFlow;
using TestSharp;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class InfrastructureSteps : StepsBase
    {
        [When(@"limpo o cache da web api")]
        public void QuandoLimpoOCacheDaWebApi()
        {
            ConfigHelper.WriteAppSetting(AppConfig.WebApiProjectFolderName, "SpecFlowHelperLastRun", DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"));
            StepHelper.OpenBaseUrl();
        }

        [When(@"reinicializo banco e servidores")]
        public void QuandoReinicializoBancoEServidores()
        {
            Database.Initialize(true);
            QuandoLimpoOCacheDaWebApi();
        }

        [When(@"reinicializo banco e servidores uma única vez para toda a feature")]
        public void QuandoReinicializoBancoEServidoresUmaUnicaVezParaTodaAFeature()
        {
            StepHooks.RunOneTimeForFeature("DatabaseReinitialized", () =>
            {
                Database.Initialize(true);
                QuandoLimpoOCacheDaWebApi();
            });
        }
    }
}
