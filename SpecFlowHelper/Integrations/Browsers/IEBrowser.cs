using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TestSharp;

namespace SpecFlowHelper.Integrations.Browsers
{
    /// <summary>
    /// The default implementation to Internet Explorer browser.
    /// </summary>
    public class IEBrowser : BrowserBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IEBrowser"/> class.
        /// </summary>
        public IEBrowser()
            : base(BrowserKind.IE, "iexplore")
        {
            WaitMilliseconds = 1000;
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
            var options = new InternetExplorerOptions();
            options.Proxy = proxy;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            return new InternetExplorerDriver(driverFolder, options);
        }

        public override void Kill()
        {
            base.Kill();
            ProcessHelper.KillAll("IEDriverServer");
        }
        #endregion
    }
}
