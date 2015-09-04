using SpecFlowHelper.Integrations.Environments;
using SpecFlowHelper.Logging;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Available environment kinds.
    /// </summary>
    public enum EnvironmentKind
    {
        /// <summary>
        /// The development environment.
        /// </summary>
        Development,

        /// <summary>
        /// The continous integration environment.
        /// </summary>
        ContinousIntegration
    }

    /// <summary>
    /// Represent the tests runtime environment.
    /// </summary>
    public static class RuntimeEnvironment
    {
        #region Properties
        /// <summary>
        /// Gets the current environment.
        /// </summary>
        public static IEnvironment Current { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the specified environment.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public static void Initialize(IEnvironment environment)
        {
            ExecutionEvents.RaiseRuntimeEnvironmentInitializing();
            LogHelper.Log("Initializing environment {0}...", environment.GetType().Name);
            Current = environment;
            Current.Initialize();
            LogHelper.Log("Environment initialized.");
            ExecutionEvents.RaiseRuntimeEnvironmentInitialized();
        }
        #endregion
    }
}
