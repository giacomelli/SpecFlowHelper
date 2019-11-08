using OpenQA.Selenium;
using SpecFlowHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Element helper.
    /// </summary>
    public static class ElementHelper
    {
        private static IWebElement _lastFoundElement;
        private static string _lastFoundElementStyle;

        /// <summary>
        /// Hightlights the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public static void Hightlight(IWebElement element)
        {
            if (AppConfig.HighlightElement
             && element != null 
             && !CIHelper.IsCI 
             && element != _lastFoundElement)
            {
                // Change the last found element back to the original style.
                if (_lastFoundElement != null)
                {
                    try
                    {
                        StepHelper.RunJS("arguments[0].setAttribute('style', arguments[1]);", _lastFoundElement, _lastFoundElementStyle);
                    }
                    catch (StaleElementReferenceException)
                    {
                        // Element is not present in page anymore.
                    }
                }

                // Highlight the current found element, changing its style.
                _lastFoundElementStyle = StepHelper.RunJS("arguments[0].getAttribute('style');", element) as string;
                StepHelper.RunJS("arguments[0].setAttribute('style','background: yellow; border: 2px solid red;');", element);

                _lastFoundElement = element;
            }
        }
    }
}
