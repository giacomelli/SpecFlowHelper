using System;
using System.Net.NetworkInformation;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations.Databases;
using SpecFlowHelper.Steps;
using TestSharp;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Represents the current database used in tests.
    /// </summary>
    public static class Database
    {
        #region Fields
        private static bool s_dbInitialized;
        private static bool s_connectionStringInitialized;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="Database"/> class.
        /// </summary>
        static Database()
        {
            if (AppConfig.InitializeDBEnabled)
            {
                DiscoverDatabase();
                Log("Connection string:{0}", Current.ConnectionString);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current.
        /// </summary>
        public static IDatabase Current { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the specified force.
        /// </summary>
        /// <param name="force">if set to <c>true</c> force the initialization.</param>
        public static void Initialize(bool force = false)
        {
            if (AppConfig.InitializeDBEnabled && (force || !s_dbInitialized))
            {
                Log("Initializing DB...");
                ExecutionEvents.RaiseDatabaseInitializing();

                InitializeConnectionString();

                s_dbInitialized = true;
                Log("DB initialized.");
                ExecutionEvents.RaiseDatabaseInitialized();
            }
        }

        /// <summary>
        /// Performs a ping to database server.
        /// </summary>
        /// <returns>The roundtrip time.</returns>
        public static int Ping()
        {
            Log("Ping {0}...", Current.Server);
            var ping = new Ping();
            var result = ping.Send(Current.Server, 10000);

            return Convert.ToInt32(result.RoundtripTime);
        }

        /// <summary>
        /// Discovers the database.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">No database server available!</exception>
        private static void DiscoverDatabase()
        {
            var availableServers = RuntimeEnvironment.Current.AvailableDatabases;

            foreach (var db in availableServers)
            {
                Log("Testing database server {0}...", db.Server);
                var ping = new Ping();

                try
                {
                    var result = ping.Send(db.Server, 2000);

                    if (result.Status == IPStatus.Success)
                    {
                        Log("Database selected {0}...", db.Server);
                        Current = db;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.GetBaseException().Message);
                }
            }

            if (Current == null)
            {
                throw new InvalidOperationException("No database server available!");
            }
        }

        private static void Log(string message, params object[] args)
        {
            StepHelper.Log(message, args);
        }

        private static void InitializeConnectionString()
        {
            if (!s_connectionStringInitialized)
            {
                SqlHelper.ConnectionString = Current.ConnectionString;
                s_connectionStringInitialized = true;
            }
        }
        #endregion
    }
}
