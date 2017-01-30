namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for browser steps strategies.
    /// </summary>
    public interface IBrowserStepsStrategy : IStepsStrategy<BrowserSteps>
    {
        /// <summary>
        /// When confirm the alert.
        /// </summary>
        void WhenConfirmTheAlert();
    }
}
