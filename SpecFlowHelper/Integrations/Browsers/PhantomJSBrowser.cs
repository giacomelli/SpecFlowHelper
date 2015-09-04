using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SpecFlowHelper.Integrations.Browsers
{
    /// <summary>
    /// The default implementation to PhantomJS browser.
    /// </summary>
    public class PhantomJSBrowser : BrowserBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PhantomJSBrowser"/> class.
        /// </summary>
        public PhantomJSBrowser()
            : base(BrowserKind.PhantomJS, "phantomjs")
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
            var options = new PhantomJSOptions();
            options.AddAdditionalCapability(CapabilityType.Proxy, proxy);

            return new PhantomJSDriver(driverFolder, options);
        }
        #endregion
    }
}
