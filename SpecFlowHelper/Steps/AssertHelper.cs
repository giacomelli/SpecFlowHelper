using System;
using System.Text.RegularExpressions;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using TestSharp;

namespace SpecFlowHelper.Steps
{
    public static class AssertHelper
    {
        #region Properties
        private static IWebDriver Driver
        {
            get
            {
                return Browser.Current.Driver;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Verifica se a URL atual contém com a porção informada.
        /// </summary>
        /// <param name="partialUrl">A porção que URL atual deve conter.</param>
        public static void AssertUrlContains(string partialUrl)
        {
            StepHelper.Attempt(() =>
            {
                return StepHelper.Driver.Url.Contains(partialUrl);
            });

            Assert.IsTrue(StepHelper.Driver.Url.Contains(partialUrl));
        }

        public static void AssertUrlEquals(string relativeUrl)
        {
            var fullUrl = AppConfig.UrlFormat.With(StepHelper.BaseURL, relativeUrl);

            StepHelper.Attempt(() =>
            {
                return StepHelper.Driver.Url.Equals(fullUrl);
            });

            Assert.AreEqual(fullUrl, StepHelper.Driver.Url);
        }

        /// <summary>
        /// Verifica se um texto existe no corpo da página.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        public static void AssertTextExists(string text)
        {
            var by = By.CssSelector("body");
            var regex = new Regex(Regex.Escape(text), RegexOptions.IgnoreCase);

            var exists = StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && regex.IsMatch(Driver.FindElement(by).Text);
            });

            Assert.IsTrue(exists, text);
        }

        public static bool ExistsText(string text)
        {
            var by = By.CssSelector("body");
            var regex = new Regex(Regex.Escape(text), RegexOptions.IgnoreCase);

            return StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && regex.IsMatch(Driver.FindElement(by).Text);
            });
        }


        /// <summary>
        /// Verifica se um link com texto informado.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        public static void AssertLinkExists(string text)
        {
            var by = By.LinkText(text);

            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by);
            });

            AssertIsElementPresent(by);
        }

        /// <summary>
        /// Verifica se um texto NÃO existe no corpo da página.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        public static void AssertTextNotExists(string text)
        {
            var by = By.CssSelector("body");

            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && !Driver.FindElement(by).Text.ToLowerInvariant().Contains(text.ToLowerInvariant());
            });

            Assert.IsFalse(Driver.FindElement(by).Text.ToLowerInvariant().Contains(text.ToLowerInvariant()));
        }

        /// <summary>
        /// Verifica se a propriedade Text do elemento retornado por By é iqual ao texto esperado.
        /// </summary>
        /// <param name="expectedText">O texto esperado.</param>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertTextAreEqual(string expectedText, By by)
        {
            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && expectedText.Equals(Driver.FindElement(by).Text);
            });

            Assert.AreEqual(expectedText, Driver.FindElement(by).Text);
        }

        /// <summary>
        /// Verifica se a propriedade Text do elemento retornado por By NÃO é igual ao texto esperado.
        /// </summary>
        /// <param name="expectedText">O texto esperado.</param>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertTextAreNotEqual(string expectedText, By by)
        {
            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && !expectedText.Equals(Driver.FindElement(by).Text);
            });

            Assert.AreNotEqual(expectedText, Driver.FindElement(by).Text);
        }

        /// <summary>
        /// Verifica se o atributo "value" do elemento retornado por By é igual ao valor esperado.
        /// </summary>
        /// <param name="expectedValue">O valor esperado.</param>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertValueAreEqual(string expectedValue, By by)
        {
            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && expectedValue.Trim().Equals(Driver.FindElement(by).GetAttribute("value").Trim());
            });

            Assert.AreEqual(expectedValue, Driver.FindElement(by).GetAttribute("value").Trim());
        }

        public static void AssertAllTextsAreEqual(string expectedText, By by)
        {
            StepHelper.Attempt(() =>
            {
                var elements = by.FindElements(Driver);

                foreach (var e in elements)
                {
                    Assert.AreEqual(expectedText, e.Text);
                }

                return true;
            });
        }

        public static void AssertAnyTextsAreEqual(string expectedText, By by)
        {
            StepHelper.Attempt(() =>
            {
                var elements = by.FindElements(Driver);

                foreach (var e in elements)
                {
                    if (expectedText.Equals(e.Text))
                    {
                        return true;
                    }
                }

                throw new InvalidOperationException("Expected text is not equal to any text: {0}".With(expectedText));
            });
        }

        /// <summary>
        /// Verifica se o atributo "value" do elemento retornado por by NÃO é vazio.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertValueIsNotEmpty(By by)
        {
            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by) && !String.IsNullOrWhiteSpace(Driver.FindElement(by).GetAttribute("value").Trim());
            });

            Assert.IsFalse(String.IsNullOrWhiteSpace(Driver.FindElement(by).GetAttribute("value").Trim()));
        }

        /// <summary>
        /// Verifica se o texto do item selecionado na dropdown retornada por by é igual ao texto esperado.
        /// </summary>
        /// <param name="expectedSelectedText">O texto esperado para o item selecionado.</param>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertDropdownItem(string expectedSelectedText, By by)
        {
            StepHelper.Attempt(() =>
            {
                Assert.AreEqual(expectedSelectedText, new SelectElement(Driver.FindElement(by)).SelectedOption.Text);
                return true;
            });
        }

        /// <summary>
        /// Verifica se os elementos retornados por by estão habilitados.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertIsEnabled(By by)
        {
            StepHelper.WaitElementsArePresent(by, 1);

            foreach (var element in Driver.FindElements(by))
            {
                Assert.IsTrue(element.Enabled, by + " should be enabled.");
            }
        }

        /// <summary>
        /// Verifica se os elementos retornados por by estão desabilitados.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertIsDisabled(By by)
        {
            StepHelper.WaitElementsArePresent(by, 1);

            foreach (var element in Driver.FindElements(by))
            {
                 Assert.IsFalse(element.Enabled, by + " should be disabled.");
            }
        }

        /// <summary>
        /// Verifica se as checkboxes retornadas por by estão marcadas.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertIsChecked(By by)
        {
            StepHelper.WaitElementsArePresent(by, 1);

            foreach (var element in Driver.FindElements(by))
            {
                Assert.IsTrue(element.Selected, by + " should be checked.");
            }
        }

        /// <summary>
        /// Verifica se as checkboxes retornadas por by NÃO estão marcadas.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void AssertIsNotChecked(By by)
        {
            StepHelper.WaitElementsArePresent(by, 1);

            foreach (var element in Driver.FindElements(by))
            {
                Assert.IsFalse(element.Selected, by + " should be not checked.");
            }
        }

        /// <summary>
        /// Verifica se o elemento está presente na página.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <returns>True se está presente, false no contrário.</returns>
        public static void AssertIsElementPresent(By by)
        {
            StepHelper.Attempt(() =>
            {
                return IsElementPresent(by);
            });

            Assert.IsNotNull(by.FindElement(Driver));
        }

        /// <summary>
        /// Verifica se o elemento não está presente na página.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <returns>True se está presente, false no contrário.</returns>
        public static void AssertIsElementNotPresent(By by)
        {
            StepHelper.Attempt(() =>
            {
                return !IsElementPresent(by);
            });

            ExceptionAssert.IsThrowing(typeof(NoSuchElementException), () =>
            {
                by.FindElement(Driver);
            });
        }

        private static bool IsElementPresent(By by)
        {
            return StepHelper.IsElementPresent(by);
        }
        #endregion
    }
}
