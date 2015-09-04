namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default browser steps strategy.
    /// </summary>
    public class DefaultBrowserStepsStrategy : StepsStrategyBase<BrowserSteps>, IBrowserStepsStrategy
    {
        /// <summary>
        /// Whens the confirm the alert.
        /// </summary>
        public void WhenConfirmTheAlert()
        {
            StepHelper.Driver.SwitchTo().Alert().Accept();
        }
    }
}
