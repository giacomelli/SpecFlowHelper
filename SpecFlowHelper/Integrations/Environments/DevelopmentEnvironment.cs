namespace SpecFlowHelper.Integrations.Environments
{
    /// <summary>
    ///  Represents a development environment.
    /// </summary>
    public class DevelopmentEnvironment : EnvironmentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentEnvironment"/> class.
        /// </summary>
        public DevelopmentEnvironment()
        {
            Attempts = 10;
            WaitMilliseconds = 2000;
        }
    }
}
