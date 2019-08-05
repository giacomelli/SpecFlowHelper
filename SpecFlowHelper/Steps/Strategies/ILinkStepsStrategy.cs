namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for link steps strategies.
    /// </summary>
    public interface ILinkStepsStrategy : IStepsStrategy<LinkSteps>
    {
        void WhenClickTheLink(string text);
        void WhenClickTheLinkContainsText(string text);
    }
}
