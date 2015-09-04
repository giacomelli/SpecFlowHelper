namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines an interface for steps strategies.
    /// </summary>
    /// <typeparam name="TSteps">The type of the steps.</typeparam>
    public interface IStepsStrategy<TSteps> where TSteps : StepsBase
    {
        /// <summary>
        /// Gets or sets the current steps.
        /// </summary>
        TSteps CurrentSteps { get; set; }
    }
}
