using Skahal.Infrastructure.Framework.Logging;

namespace SpecFlowHelper.Logging
{
    /// <summary>
    /// The log helper.
    /// </summary>
    public static class LogHelper
    {
        #region Fields
        private static ILogStrategy s_logStrategy;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="LogHelper"/> class.
        /// </summary>
        static LogHelper()
        {
            s_logStrategy = new Log4netLogStrategy("Specs");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public static void Log(string message, params object[] args)
        {
            s_logStrategy.WriteDebug(message, args);
        }
        #endregion
    }
}
