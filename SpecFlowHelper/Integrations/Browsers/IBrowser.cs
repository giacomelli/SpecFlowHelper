using OpenQA.Selenium;

namespace SpecFlowHelper.Integrations.Browsers
{
    #region Enums
    /// <summary>
    /// Available browsers kind.
    /// </summary>
    public enum BrowserKind
    {
        /// <summary>
        /// The browser in use is Chrome.
        /// </summary>
        Chrome,

        /// <summary>
        /// The browser in use is Firefox.
        /// </summary>
        Firefox,

        /// <summary>
        /// The browser in use is IE.
        /// </summary>
        IE,

        /// <summary>
        /// The browser in use is PhantomJS.
        /// </summary>
        PhantomJS
    }
    #endregion

    /// <summary>
    /// Defines an interface for browser used in tests.
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// Gets the kind.
        /// </summary>
        BrowserKind Kind { get; }

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Gets the proxy.
        /// </summary>
        Proxy Proxy { get; }

        /// <summary>
        /// Gets the wait milliseconds used in steps for this specific browser.
        /// </summary>
        int WaitMilliseconds { get; }

        /// <summary>
        /// Initializes the browser.
        /// </summary>
        /// <param name="driverFolder">The driver folder.</param>
        /// <param name="proxy">The proxy.</param>
        void Initialize(string driverFolder, Proxy proxy);

        /// <summary>
        /// Kills this instance.
        /// </summary>
        void Kill();

        /// <summary>
        /// Navigates to iframe.
        /// </summary>
        /// <param name="by">The IFrame selector.</param>
        void NavigateToIframe(By by);

        /// <summary>
        /// Navigates the back to main window.
        /// </summary>
        void NavigateBackToMainWindow();

        /// <summary>
        /// Re-navigates to current window.
        /// </summary>
        void Renavigate();
    }
}
