namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for buton steps strategies.
    /// </summary>
    public interface IButtonStepsStrategy : IStepsStrategy<ButtonSteps>
    {
        /// <summary>
        /// When click in the button.
        /// </summary>
        /// <param name="label">The button label.</param>
        void WhenClickInTheButton(string label);
    }
}
