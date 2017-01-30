namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for infrastructure steps strategies.
    /// </summary>
    public interface IInfrastructureStepsStrategy : IStepsStrategy<InfrastructureSteps>
    {
        /// <summary>
        /// When clear web API cache.
        /// </summary>
        void WhenClearWebApiCache();

        /// <summary>
        /// When reinitialize database and servers.
        /// </summary>
        void WhenReinitializeDBAndServers();

        /// <summary>
        /// When reinitialize database and server one time to feature.
        /// </summary>
        void WhenReinitializeDBAndServerOneTimeToFeature();
    }
}
