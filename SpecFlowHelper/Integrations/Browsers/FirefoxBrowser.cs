using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowHelper.Integrations.Browsers
{
    /// <summary>
    /// The default implementation to Firefox browser.
    /// </summary>
    public class FirefoxBrowser : BrowserBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FirefoxBrowser"/> class.
        /// </summary>
        public FirefoxBrowser()
            : base(BrowserKind.Firefox, "firefox")
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs the initialize of the browser.
        /// </summary>
        /// <param name="driverFolder">The driver folder.</param>
        /// <param name="proxy">The proxy.</param>
        /// <returns>
        /// The web driver.
        /// </returns>
        protected override IWebDriver PerformInitialize(string driverFolder, Proxy proxy)
        {
            var profile = new FirefoxProfile();
            profile.SetProxyPreferences(proxy);
            return new FirefoxDriver(profile);
        }
        #endregion
    }
}
