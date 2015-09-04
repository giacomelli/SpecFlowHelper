namespace SpecFlowHelper.Integrations.Databases
{
    /// <summary>
    /// Defines an interface for database used in tests.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets the server.
        /// </summary>
        string Server { get; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        string ConnectionString { get; }
    }
}
