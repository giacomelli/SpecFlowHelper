using SpecFlowHelper.Logging;
using System;

namespace SpecFlowHelper.Integrations.Environments
{
    /// <summary>
    /// Represents a CI (Continuous Integration) environment.
    /// <remarks>
    /// This environment use environment variables defined on SO as it's config:
    /// seleniumAttempts: defines the Attempts property.
    /// seleniumImplicitlyWaitSeconds: defines the Selenium ImplicitlyWait value.
    /// httpProxy: defines the proxy that should be used on browser.
    /// </remarks>
    /// </summary>
    public class ContinousIntegrationEnvironment : EnvironmentBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ContinousIntegrationEnvironment"/> class.
        /// </summary>
        public ContinousIntegrationEnvironment()
        {
            Attempts = Convert.ToInt32(Environment.GetEnvironmentVariable("seleniumAttempts"));
            LogHelper.Log("Attempts read from seleniumAttempts environment variable: {0}", Attempts);
            WaitMilliseconds = 3000;
            ShouldAbortOnFirstTestError = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the environment.
        /// </summary>
        public override void Initialize()
        {
            ExecutionEvents.BrowserInitializing += (sender, args) =>
            {
                Browser.Current.Kill();
            };

            var implicitlyWaitSeconds = TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("seleniumImplicitlyWaitSeconds")));
            LogHelper.Log("ImplicitlyWait read from seleniumImplicitlyWaitSeconds environment variable: {0}", implicitlyWaitSeconds);

            ExecutionEvents.BrowserInitialized += (sender, args) =>
            {
                var driver = Browser.Current.Driver;
                driver.Manage().Timeouts().ImplicitlyWait(implicitlyWaitSeconds);

                var proxy = Browser.Current.Proxy;
                proxy.HttpProxy = Environment.GetEnvironmentVariable("httpProxy");
                proxy.IsAutoDetect = false;
            };

            ExecutionEvents.IframeNavigated += (sender, args) =>
            {
                var driver = Browser.Current.Driver;
                driver.Manage().Timeouts().ImplicitlyWait(implicitlyWaitSeconds);
            };
        }
        #endregion
    }
}
