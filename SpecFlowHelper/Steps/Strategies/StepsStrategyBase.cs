namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines an interface for steps strategies.
    /// </summary>
    /// <typeparam name="TSteps">The type of the steps.</typeparam>
    public abstract class StepsStrategyBase<TSteps> : IStepsStrategy<TSteps> where TSteps : StepsBase
    {
        /// <summary>
        /// Gets or sets the current steps.
        /// </summary>
        public TSteps CurrentSteps { get; set; }
    }
}
