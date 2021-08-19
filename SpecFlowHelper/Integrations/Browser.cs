using System;
using HelperSharp;
using OpenQA.Selenium;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations.Browsers;
using SpecFlowHelper.Logging;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Represents the current browser used in tests.
    /// </summary>
    public static class Browser
    {
        #region Fields
        private static bool s_initialized;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current.
        /// </summary>
        public static IBrowser Current { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the browser.
        /// </summary>
        /// <param name="kind">The browser kind.</param>
        /// <returns>The web driver.</returns>
        public static IWebDriver Initialize(BrowserKind kind)
        {
            if (!s_initialized)
            {
                LogHelper.Log("Initializing browser...");

                var driversFolder = AppConfig.BrowserDriverFolder;
                var proxy = new Proxy();

                switch (kind)
                {
                    case BrowserKind.Chrome:
                        Current = new ChromeBrowser();
                        break;

                    case BrowserKind.Firefox:
                        Current = new FirefoxBrowser();
                        break;

                    case BrowserKind.IE:
                        Current = new IEBrowser();
                        break;

                    case BrowserKind.PhantomJS:
                        Current = new PhantomJSBrowser();
                        break;

                    default:
                        throw new InvalidOperationException("Browser {0} not supported.".With(kind));
                }

                LogHelper.Log("{0} selected.", kind);
                ExecutionEvents.RaiseBrowserInitializing();
                ExecutionEvents.RaiseProxyInitializing(proxy);
                Current.Initialize(driversFolder, proxy);
                LogHelper.Log("Browser initialized.");
                s_initialized = true;
                ExecutionEvents.RaiseBrowserInitialized();
            }

            return Current.Driver;
        }
        #endregion
    }
}
