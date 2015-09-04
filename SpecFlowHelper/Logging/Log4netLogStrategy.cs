using System;

namespace SpecFlowHelper.Logging
{
    /// <summary>
    /// Estratégia de log.
    /// </summary>
    public class Log4netLogStrategy : Skahal.Infrastructure.Logging.Log4net.Log4netLogStrategy
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="LogStrategy"/>.
        /// </summary>
        /// <param name="loggerName">O nome do logger.</param>
        public Log4netLogStrategy(string loggerName)
            : base(loggerName)
        {
        }

        /// <summary>
        /// Writes the debug log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteDebug(string message, params object[] args)
        {
            RunSafety(base.WriteDebug, message, args);
        }

        /// <summary>
        /// Writes the warning log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteWarning(string message, params object[] args)
        {
            RunSafety(base.WriteWarning, message, args);
        }

        /// <summary>
        /// Writes the error log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteError(string message, params object[] args)
        {
            RunSafety(base.WriteError, message, args);
        }

        private static void RunSafety(Action<string, object[]> write, string message, object[] args)
        {
            try
            {
                write(message, args);
            }
            catch (Exception)
            {
                var escapedMessage = message;

                if (!String.IsNullOrEmpty(escapedMessage))
                {
                    escapedMessage = escapedMessage.Replace("{", "{{").Replace("}", "}}");

                    write(escapedMessage, args);
                }
            }
        }
    }
}
