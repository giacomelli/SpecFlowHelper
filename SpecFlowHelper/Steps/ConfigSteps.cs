using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Config steps.
    /// </summary>
    [Binding]
    public class ConfigSteps : StepsBase
    {
        #region Properties
        private IConfigStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IConfigStepsStrategy, ConfigSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When change web.config key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        [When(Locale.WhenChangeWebConfigKey)]
        public void WhenChangeWebConfigKey(string key, string value)
        {
            Strategy.WhenChangeWebConfigKey(key, value);
        }
        #endregion
    }
}
