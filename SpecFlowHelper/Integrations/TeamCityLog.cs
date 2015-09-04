using System;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Writes logs to TeamCity build log.
    /// </summary>
    public static class TeamCityLog
    {
        #region Fields
        private static string s_currentScenarioTitle;
        #endregion

        #region Methods
        /// <summary>
        /// Writes the feature begin.
        /// </summary>
        /// <param name="title">The title.</param>
        public static void WriteFeatureBegin(string title)
        {
            Console.WriteLine("##teamcity[testSuiteStarted name='{0}']", SanitizeText(title));
            WriteBuildLog(title);
        }

        /// <summary>
        /// Writes the scenario begin.
        /// </summary>
        /// <param name="title">The title.</param>
        public static void WriteScenarioBegin(string title)
        {
            s_currentScenarioTitle = title;
            Console.WriteLine("##teamcity[testStarted name='{0}' captureStandardOutput='true']", SanitizeText(title));
            WriteBuildLog(title);
        }

        /// <summary>
        /// Writes the scenario end.
        /// </summary>
        /// <param name="title">The title.</param>
        public static void WriteScenarioEnd(string title)
        {
            Console.WriteLine("##teamcity[testFinished name='{0}']", SanitizeText(title));
            WriteBuildLog(title);
        }

        /// <summary>
        /// Writes the feature end.
        /// </summary>
        /// <param name="title">The title.</param>
        public static void WriteFeatureEnd(string title)
        {
            Console.WriteLine("##teamcity[testSuiteFinished name='{0}']", SanitizeText(title));
            WriteBuildLog(title);
        }

        /// <summary>
        /// Writes the test message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteTestMessage(string message)
        {
            Console.WriteLine("##teamcity[testStdOut name='{0}' out='{1}']", s_currentScenarioTitle, SanitizeText(message));
            WriteBuildLog(message);
        }

        /// <summary>
        /// Writes the build log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteBuildLog(string message)
        {
            Console.WriteLine("##teamcity[message text='{0}' status='NORMAL']", SanitizeText(message));
        }

        private static string SanitizeText(string message)
        {
            message = message.Replace("'", "\\'");

            return message;
        }
        #endregion
    }
}