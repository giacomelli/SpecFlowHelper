namespace SpecFlowHelper.Integrations.Databases
{
    /// <summary>
    /// A SQL Server's IDatabase implementation.
    /// </summary>
    public class SqlServerDatabase : IDatabase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDatabase"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="connectionString">The connection string.</param>
        public SqlServerDatabase(string server, string connectionString)
        {
            Server = server;
            ConnectionString = connectionString;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the server.
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public string ConnectionString { get; private set; }
        #endregion
    }
}
