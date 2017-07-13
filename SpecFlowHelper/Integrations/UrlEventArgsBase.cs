using System;
using OpenQA.Selenium;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// URL event args base class.
    /// </summary>
    public abstract class UrlEventArgsBase : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlEventArgsBase"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        protected UrlEventArgsBase(IWebDriver driver, string baseUrl, string relativeUrl)
        {
            Driver = driver;
            BaseUrl = baseUrl;
            RelativeUrl = relativeUrl;
        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the driver.
        /// </summary>
        public IWebDriver Driver { get; protected set; }

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        public string BaseUrl { get; protected set; }

        /// <summary>
        /// Gets relative URL.
        /// </summary>
        public string RelativeUrl { get; protected set; }
        #endregion
    }
}
