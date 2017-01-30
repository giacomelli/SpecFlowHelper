namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for config steps strategies.
    /// </summary>
    public interface IConfigStepsStrategy : IStepsStrategy<ConfigSteps>
    {
        /// <summary>
        /// When change web.config key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void WhenChangeWebConfigKey(string key, string value);
    }
}
