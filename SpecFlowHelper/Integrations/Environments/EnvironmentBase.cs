using System.Collections.Generic;
using SpecFlowHelper.Integrations.Databases;

namespace SpecFlowHelper.Integrations.Environments
{
    /// <summary>
    /// A base class for test runtime environments.
    /// </summary>
    public abstract class EnvironmentBase : IEnvironment
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentBase"/> class.
        /// </summary>
        protected EnvironmentBase()
        {
            AvailableDatabases = new List<IDatabase>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the how many attempts a step should try in this environment.
        /// </summary>
        public int Attempts { get; protected set; }

        /// <summary>
        /// Gets or sets the wait milliseconds.
        /// </summary>
        public int WaitMilliseconds { get; protected set; }

        /// <summary>
        /// Gets or sets the available databases.
        /// </summary>
        public IList<IDatabase> AvailableDatabases { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether should use database ping as sleep time.
        /// </summary>
        /// <value>
        /// <c>true</c> if should use database ping as sleep time; otherwise, <c>false</c>.
        /// </value>
        public bool UseDatabasePingAsSleep { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether should abort on first test error.
        /// </summary>
        /// <value>
        /// <c>true</c> if should abort on first test error; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldAbortOnFirstTestError { get; protected set; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the environment.
        /// </summary>
        public virtual void Initialize()
        {
        }
        #endregion
    }
}
