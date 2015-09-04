using System;
using HelperSharp;
using OpenQA.Selenium;
using SpecFlowHelper.Logging;
using TestSharp;

namespace SpecFlowHelper.Integrations.Browsers
{
    /// <summary>
    /// A base implementation of IBrowser.
    /// </summary>
    public abstract class BrowserBase : IBrowser
    {
        #region Fields
        private string m_processName;
        private By m_currentIframeSelector;
        private string m_currentIFrameUrl;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserBase"/> class.
        /// </summary>
        /// <param name="kind">The browser kind.</param>
        /// <param name="processName">The name of the browser process.</param>
        protected BrowserBase(BrowserKind kind, string processName)
        {
            Kind = kind;
            m_processName = processName;
            WaitMilliseconds = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the kind.
        /// </summary>
        public BrowserKind Kind { get; private set; }

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Gets the proxy.
        /// </summary>
        public Proxy Proxy { get; private set; }

        /// <summary>
        /// Gets the wait milliseconds used in steps for this specific browser.
        /// </summary>
        public int WaitMilliseconds { get; protected set; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the browser.
        /// </summary>
        /// <param name="driverFolder">The driver folder.</param>
        /// <param name="proxy">The proxy.</param>
        public void Initialize(string driverFolder, Proxy proxy)
        {
            Proxy = proxy;
            Driver = PerformInitialize(driverFolder, proxy);
        }

        /// <summary>
        /// Kills this instance.
        /// </summary>
        public void Kill()
        {
            ProcessHelper.KillAll(m_processName);
        }

        /// <summary>
        /// Navigates to iframe.
        /// </summary>
        /// <param name="by">The IFrame selector.</param>
        public void NavigateToIframe(By by)
        {
            var previousUrl = Driver.Url;
            var iframeDriver = Driver.SwitchTo().Frame(Driver.FindElement(by));

            if (iframeDriver.Url.Equals(previousUrl))
            {
                throw new InvalidOperationException("Cannot navigate to iframe {0}".With(by));
            }

            Driver = iframeDriver;
            m_currentIframeSelector = by;
            m_currentIFrameUrl = Driver.Url;
            LogHelper.Log("NavigateToIframe: from url {0} to {1}", previousUrl, Driver.Url);
            ExecutionEvents.RaiseIframeNavigated();
        }

        /// <summary>
        /// Re-navigates to current window.
        /// </summary>
        public void Renavigate()
        {
            if (m_currentIframeSelector != null && !Driver.Url.Equals(m_currentIFrameUrl))
            {
                NavigateToIframe(m_currentIframeSelector);
            }
        }


        /// <summary>
        /// Navigates the back to main window.
        /// </summary>
        public void NavigateBackToMainWindow()
        {
            var previousUrl = Driver.Url;
            Driver = Driver.SwitchTo().DefaultContent();
            m_currentIframeSelector = null;
            m_currentIFrameUrl = null;

            LogHelper.Log("NavigateBackToMainWindow: from url {0} to {1}", previousUrl, Driver.Url);
        }

        /// <summary>
        /// Performs the initialize of the browser.
        /// </summary>
        /// <param name="driverFolder">The driver folder.</param>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The web driver.</returns>
        protected abstract IWebDriver PerformInitialize(string driverFolder, Proxy proxy);
        #endregion
    }
}
