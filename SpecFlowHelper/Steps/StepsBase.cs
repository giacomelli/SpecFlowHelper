using OpenQA.Selenium;
using SpecFlowHelper.Integrations;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// A base class for Steps.
    /// </summary>
    public abstract class StepsBase : TechTalk.SpecFlow.Steps
    {
        #region Properties
        /// <summary>
        /// Gets the web driver.
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                return Browser.Current.Driver;
            }
        }
        #endregion
    }
}
