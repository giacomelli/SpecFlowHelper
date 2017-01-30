namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for checkbox steps strategies.
    /// </summary>
    public interface ICheckboxStepsStrategy : IStepsStrategy<CheckboxSteps>
    {
        /// <summary>
        /// When check the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        void WhenCheckTheCheckbox(string checkbox);

        /// <summary>
        /// Whens uncheck the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        void WhenUncheckTheCheckbox(string checkbox);
    }
}
