namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for toast steps strategies.
    /// </summary>
    public interface IToastStepsStrategy : IStepsStrategy<ToastSteps>
    {
        void ThenShouldShowTheToast(string message);

        void ThenCloseTheToast();
    }
}
