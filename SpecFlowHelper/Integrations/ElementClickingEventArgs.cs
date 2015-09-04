using System;
using OpenQA.Selenium;

namespace SpecFlowHelper.Integrations
{
    public class ElementClickingEventArgs : EventArgs
    {
        #region Constructors
        public ElementClickingEventArgs(IWebElement element)
        {
            Element = element;
        }
        #endregion

        #region Properties
        public IWebElement Element { get; private set; }
        #endregion
    }
}
