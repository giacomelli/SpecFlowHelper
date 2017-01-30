namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for badge steps strategies.
    /// </summary>
    public interface IBadgeStepsStrategy : IStepsStrategy<BadgeSteps>
    {
        /// <summary>
        /// Then should show the badge with the text.
        /// </summary>
        void ThenShouldShowTheBadgeWithTheText(string text);
    }
}
