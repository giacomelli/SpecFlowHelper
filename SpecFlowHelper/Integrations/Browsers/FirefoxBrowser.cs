using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestSharp;

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
            var options = new FirefoxOptions();
            options.Proxy = proxy;
            return new FirefoxDriver(options);
        }

        public override void Kill()
        {
            base.Kill();
            ProcessHelper.KillAll("FirefoxDriver");
        }
        #endregion
    }
}
