using System;
using OpenQA.Selenium;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Url opened event args.
    /// </summary>
    public class UrlOpenedEventArgs : UrlEventArgsBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlOpenedEventArgs"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        public UrlOpenedEventArgs(IWebDriver driver, string baseUrl, string relativeUrl)
            :base(driver, baseUrl, relativeUrl)
        {
        }
        #endregion        
    }
}
