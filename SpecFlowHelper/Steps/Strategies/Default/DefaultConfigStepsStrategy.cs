using SpecFlowHelper.Configuration;
using TestSharp;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default config steps strategy.
    /// </summary>
    public class DefaultConfigStepsStrategy : StepsStrategyBase<ConfigSteps>, IConfigStepsStrategy
    {
        /// <summary>
        /// When change web.config key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void WhenChangeWebConfigKey(string key, string value)
        {
            ConfigHelper.WriteAppSetting(AppConfig.WebApiProjectFolderName, key, value);
        }
    }
}