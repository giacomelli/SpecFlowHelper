namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for textbox steps strategies.
    /// </summary>
    public interface ITextboxStepsStrategy : IStepsStrategy<TextboxSteps>
    {
        void WhenTypeOnTheField(string value, string field);
        void ThenTheFieldShouldHaveTheValue(string field, string value);

        void WhenTypeEnterOnTheField(string field);

        void WhenTypeEnterOnTheElement(string field);
    }
}
