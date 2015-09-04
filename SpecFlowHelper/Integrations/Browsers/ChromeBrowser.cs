using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SpecFlowHelper.Integrations.Browsers
{
    /// <summary>
    /// The default implementation to Chrome browser.
    /// </summary>
    public class ChromeBrowser : BrowserBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeBrowser"/> class.
        /// </summary>
        public ChromeBrowser()
            : base(BrowserKind.Chrome, "chrome")
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
            var options = new ChromeOptions();

            if (!string.IsNullOrWhiteSpace(proxy.HttpProxy))
            {
                options.AddAdditionalCapability(CapabilityType.Proxy, proxy);
            }

            return new ChromeDriver(driverFolder, options);
        }
        #endregion
    }
}
