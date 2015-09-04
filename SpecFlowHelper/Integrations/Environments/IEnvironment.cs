using System.Collections.Generic;
using SpecFlowHelper.Integrations.Databases;

namespace SpecFlowHelper.Integrations.Environments
{
    /// <summary>
    /// Defines an interface for runtime test environment.
    /// </summary>
    public interface IEnvironment
    {
        /// <summary>
        /// Gets the how many attempts a step should try in this environment.
        /// </summary>
        int Attempts { get; }

        /// <summary>
        /// Gets the wait milliseconds.
        /// </summary>
        /// <value>
        /// The wait milliseconds.
        /// </value>
        int WaitMilliseconds { get; }

        /// <summary>
        /// Gets the available databases.
        /// </summary>
        IList<IDatabase> AvailableDatabases { get; }

        /// <summary>
        /// Gets a value indicating whether should use database ping as sleep time.
        /// </summary>
        /// <value>
        /// <c>true</c> if should use database ping as sleep time; otherwise, <c>false</c>.
        /// </value>
        bool UseDatabasePingAsSleep { get; }

        /// <summary>
        /// Gets a value indicating whether should abort on first test error.
        /// </summary>
        /// <value>
        /// <c>true</c> if should abort on first test error; otherwise, <c>false</c>.
        /// </value>
        bool ShouldAbortOnFirstTestError { get; }

        /// <summary>
        /// Initializes the environment.
        /// </summary>
        void Initialize();
    }
}
