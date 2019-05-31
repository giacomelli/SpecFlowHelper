using OpenQA.Selenium;
using TestSharp;

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
            throw new System.NotImplementedException();
            //var options = new PhantomJSOptions();
            //options.AddAdditionalCapability(CapabilityType.Proxy, proxy);

            //return new PhantomJSDriver(driverFolder, options);
        }

        public override void Kill()
        {
            base.Kill();
            ProcessHelper.KillAll("phantomjs");
        }
        #endregion
    }
}
