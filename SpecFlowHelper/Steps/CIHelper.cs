using System;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Continous integration helper.
    /// </summary>
    public static class CIHelper
    {
        /// <summary>
        /// Is running on a continuous integrations server.
        /// </summary>
        public static readonly bool IsCI;

        static CIHelper()
        {
            IsCI = !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("BUILD_BUILDID")); // Azure DevOps.

            StepHelper.Log($"CIHelper.IsCI: {IsCI}");
        }        
    }
}
