namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for checkbox steps strategies.
    /// </summary>
    public interface IRadioButtonStepsStrategy : IStepsStrategy<RadioButtonSteps>
    {
        void WhenCheckTheRadioButton(string radioButton);
        void ThenTheRadioButtonShouldBeReadOnly(string radiobutton);
    }
}
