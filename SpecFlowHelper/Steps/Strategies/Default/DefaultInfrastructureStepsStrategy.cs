using System;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using TestSharp;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default infrastructure steps strategy.
    /// </summary>
    public class DefaultInfrastructureStepsStrategy : StepsStrategyBase<InfrastructureSteps>, IInfrastructureStepsStrategy
    {
        /// <summary>
        /// When clear web API cache.
        /// </summary>
        public virtual void WhenClearWebApiCache()
        {
            var api = AppConfig.WebProjects.SingleWebApi();
            ConfigHelper.WriteAppSetting(api.FolderName, "SpecFlowHelperLastRun", DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"));
            StepHelper.OpenBaseUrl();
        }

        /// <summary>
        /// When reinitialize database and servers.
        /// </summary>
        public virtual void WhenReinitializeDBAndServers()
        {
            Database.Initialize(true);
            WhenClearWebApiCache();
        }

        /// <summary>
        /// When reinitialize database and server one time to feature.
        /// </summary>
        public void WhenReinitializeDBAndServerOneTimeToFeature()
        {
            StepHooks.RunOneTimeForFeature("DatabaseReinitialized", () =>
            {
                Database.Initialize(true);
                WhenClearWebApiCache();
            });
        }
    }
}