using System;
using OpenQA.Selenium;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// UrlOpening event args.
    /// </summary>
    public class UrlOpeningEventArgs : UrlEventArgsBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlOpeningEventArgs"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        public UrlOpeningEventArgs(IWebDriver driver, string baseUrl, string relativeUrl)
            :base(driver, baseUrl, relativeUrl)
        {
        }
        #endregion        
    }
}
