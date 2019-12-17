using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using HelperSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using SpecFlowHelper.Logging;
using TechTalk.SpecFlow;
using TestSharp;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Utilitários para steps;
    /// </summary>
    public static class StepHelper
    {
        public static event EventHandler ScenarioBegin;
        public static event EventHandler AttemptBegin;
        public static event EventHandler<Exception> ErrorOcurred;
        #region Fields
        private static IJavaScriptExecutor s_jsExecutor;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="StepHelper"/> class.
        /// </summary>
        static StepHelper()
        {
            Log("Initializing SpecFlowHelper...");
            AppConfig.Validate();
            StartWebServers();
        }

        internal static void ThrowScenarioTimeout()
        {
            var ex = new TimeoutException("ScenarioTimeout reach: {0}".With(AppConfig.ScenarioTimeout));
            RaiseErrorOcurred(ex);
            throw ex;
        }

        internal static void RaiseScenarioBegin()
        {
            ScenarioBegin?.Invoke(typeof(StepHelper), EventArgs.Empty);
        }

        internal static void RaiseErrorOcurred(Exception ex)
        {
            try
            {
                ErrorOcurred?.Invoke(typeof(StepHelper), ex);
            }
            catch(Exception newEx)
            {
                StepHelper.Log($"Error while raising 'ErrorOcurred'. Please, check your code: {newEx.Message}");
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Obtém o web driver.
        /// </summary>
        public static IWebDriver Driver
        {
            get
            {
                return Browser.Current.Driver;
            }
        }

        /// <summary>
        /// Obtém ou define a URL base do teste.
        /// </summary>
        public static string BaseURL
        {
            get
            {
                return AppConfig.BaseUrlSolver.Solve(ScenarioContext.Current, Driver);
            }
        }

        #endregion

        #region Methods

        #region Initialize and quit
        public static void StartWebServers()
        {
            StopWebServers();

            Log($"Using IIS Express from '{WebHostHelper.WebDevWebServerPath}...");

            foreach (var webProject in AppConfig.WebProjects)
            {
                if (webProject.BaseUrl.Contains("://localhost") && !String.IsNullOrEmpty(webProject.FolderName))
                {
                    Log($"Starting {webProject.FolderName} ({webProject.BaseUrl})...");
                    WebHostHelper.StartAndWaitForResponse(webProject.FolderName, webProject.Port, webProject.ExpectedStatusCode);
                }
                else
                {
                    Log($"Using {webProject.FolderName} published on {webProject.BaseUrl}...");
                }
            }
        }       

        public static void StopWebServers()
        {
            Log("Killing web server processes...");
            ProcessHelper.KillAll(WebHostHelper.WebHostProcessName);
            ProcessHelper.KillAll("iisexpress");
            WebHostHelper.KillAll();
        }

        /// <summary>
        /// Inicializa o driver.
        /// </summary>
        public static void InitializeDriver()
        {
            RuntimeEnvironment.Initialize(AppConfig.Environment);
            Database.Initialize();
            Browser.Initialize(AppConfig.BrowserKind);

            s_jsExecutor = Driver as IJavaScriptExecutor;
            ExecutionEvents.RaiseWebDriverInitialized();
        }

        public static void OpenBaseUrl()
        {
            Driver.Navigate().GoToUrl(BaseURL);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Finaliza o driver.
        /// </summary>
        public static void Quit()
        {
            try
            {
                StopWebServers();
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static object RunJS(string js, params object[] args)
        {
            if (s_jsExecutor != null)
            {
                return s_jsExecutor.ExecuteScript(js, args);
            }

            return null;
        }

        public static void WriteToBrowserConsole(string message, params object[] args)
        {
            RunJS("console.log(\"{0}\");".With(message.With(args)));
        }
        #endregion

        #region Windows and iframes
        public static void NavigateToIframeWithSrc(string src)
        {
            var by = By.XPath("//iframe[@src='{0}']".With(src));
            NavigateToIframe(by);
        }

        public static void NavigateToIframe(By by)
        {
            StepHelper.Attempt(() =>
            {
                Browser.Current.NavigateToIframe(by);
                return true;
            });
        }

        public static void NavigateBackToMainWindow()
        {
            Browser.Current.NavigateBackToMainWindow();
        }

        public static void ScrollToTop()
        {
            RunJS("window.scrollTo(0, 0)");
        }

        public static void ScrollToBottom()
        {
            RunJS("window.scrollTo(0, document.body.scrollHeight)");
        }
        #endregion

        #region Elements
        /// <summary>
        /// Localiza o elemento especificado por by.
        /// <remarks>
        /// Realiza algumas tentativas caso o elemento ainda não esteja presente na página.
        /// </remarks>
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <returns></returns>      
        public static IWebElement FindElement(By by)
        {
            try
            {
                var currentFoundElement = Driver.FindElements(by).First(e => e.Displayed);

                ElementHelper.Hightlight(currentFoundElement);

                return currentFoundElement;
            }
            catch (InvalidOperationException ex)
            {
                Log("Element '{0}' not found.", by);
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se o elemento existe.
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool IsElementPresent(By by)
        {
            try
            {
                var element = Driver.FindElement(by);
                ElementHelper.Hightlight(element);

                return element != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks on specified element.
        /// </summary>
        /// <param name="by">The element selector.</param>
        public static void Click(By by, int attempts = 10)
        {
            try
            {
                Attempt(() =>
                {
                    ClickOnce(by, false);

                    return true;
                }, attempts);
            }
            catch (Exception)
            {
                ClickOnce(by, true);
            }
        }

        /// <summary>
        /// Clicks on the first element element available.
        /// </summary>
        /// <param name="by">The elements selectors.</param>
        /// <param name="attempts">The attempts.</param>
        public static void ClickAny(IEnumerable<By> selectors, int attempts = 10)
        {

            Attempt(() =>
            {
                var clicked = false;

                foreach (var by in selectors)
                {
                    try
                    {
                        ClickOnce(by, false);
                        clicked = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                return clicked;
            }, attempts);

        }

        public static void ClickOnce(By by, bool tryMoveByOffset = true)
        {
            try
            {
                var element = FindElement(by);

                if (!element.Enabled)
                {
                    throw new InvalidOperationException("Element is not enabled.");
                }

                ExecutionEvents.RaiseElementClicking(new ElementClickingEventArgs(element));
                element.Click();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Element is not clickable at point"))
                {
                    StepHelper.MoveToElement(by);

                    if (tryMoveByOffset)
                    {
                        var element = FindElement(by);
                        var actions = new Actions(Driver);
                        actions
                            .MoveToElement(element)
                            .MoveByOffset(1, 0)
                            .Click()
                            .Build()
                            .Perform();
                    }

                    return;
                }

                throw;
            }
        }

        public static void MoveToElement(By by, int attempts = 10)
        {
            Attempt(() =>
            {
                var element = FindElement(by);

                var actions = new Actions(Driver);
                actions.MoveToElement(element).Build().Perform();

                return true;
            }, attempts);
        }

        public static void Blur(By by, int attempts = 10)
        {
            Attempt(() =>
            {
                var element = FindElement(By.TagName("body"));

                var actions = new Actions(Driver);
                actions.MoveToElement(element).Build().Perform();

                return true;
            }, attempts);
        }

        /// <summary>
        /// Executa um clique-duplo no elemento especificado por by.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        public static void DoubleClick(By by)
        {
            Attempt(() =>
            {
                var element = FindElement(by);

                var actions = new Actions(Driver);
                actions.MoveToElement(element).DoubleClick(element).Perform();

                return true;
            });
        }

        /// <summary>
        /// Seleciona o item da dropdown retornada por by que possui o texto especificado.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <param name="itemText">O texto do item a ser selecionado.</param>
        public static void SelectDropdownItem(By by, string itemText)
        {
            StepHelper.Attempt(() =>
            {
                new SelectElement(FindElement(by)).SelectByText(itemText);
                return true;
            });
        }

        /// <summary>
        /// Seleciona um item da dropdown do tipo Select2
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <param name="itemText">O texto do item a ser selecionado.</param>
        public static void Select2DropdownItem(By by, string itemText)
        {
            var select2 = FindElement(by);
            select2.Click();

            string subContainerClass = "#select2-drop:not([style*='display: none'])";
            var searchBox = FindElement(By.CssSelector(subContainerClass + " .select2-input"));
            searchBox.SendKeys(itemText);

            var selectedItem = FindElement(By.CssSelector(subContainerClass + " .select2-results li.select2-result-selectable"));
            selectedItem.Click();
        }

        /// <summary>
        /// Realiza algumas tentativas caso o elemento retornado por by ainda não esteja presente na página.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <param name="attempts">O número de tentativas.</param>
        public static IWebElement WaitElementIsPresent(By by, int attempts = 10)
        {
            Attempt(() =>
            {
                return IsElementPresent(by);
            }, attempts);

            if (!IsElementPresent(by))
            {
                throw new InvalidOperationException("Element is not present: " + by);
            }

            return FindElement(by);
        }

        public static void WaitElementIsNotVisible(By by, int attempts)
        {
            Attempt(() =>
            {
                try
                {
                    var element = Driver.FindElement(by);


                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            }, attempts);

            try
            {
                if (Driver.FindElement(by).Displayed)
                {
                    throw new InvalidOperationException("Element is visible: " + by);
                }
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        /// <summary>
        /// Realiza algumas tentativas caso os elementos retornados por by ainda não estejam presentes na página.
        /// </summary>
        /// <param name="by">O seletor do elemento.</param>
        /// <param name="minLength">A quantidade mínima de elementos.</param>
        public static void WaitElementsArePresent(By by, int minLength)
        {
            Attempt(() =>
            {
                if (AreElementsPresent(by))
                {
                    var elementsCount = Driver.FindElements(by).Count;

                    if (elementsCount >= minLength)
                    {
                        return true;
                    }
                }

                return false;
            });

            if (Driver.FindElements(by).Count < minLength)
            {
                throw new InvalidOperationException("Elements are not present: " + by);
            }
        }

        /// <summary>
        /// Verifica se os elementos estão presentes na página.
        /// </summary>
        /// <param name="by">O seletor dos elementos.</param>
        /// <returns>True se estão presentes, false no contrário.</returns>
        public static bool AreElementsPresent(By by)
        {
            try
            {
                Driver.FindElements(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Entra o valor informado no elemento retornado por by.
        /// </summary>
        /// <param name="by">O seletor dos elementos.</param>
        /// <param name="value">O valor.</param>
        public static void EnterValue(By by, string value, bool isInputFile = false)
        {
            Attempt(() =>
            {
                WaitElementIsPresent(by, 1);

                var element = FindElement(by);

                if (!isInputFile)
                {
                    element.Clear();
                }

                element.SendKeys(value);
                return true;
            });
        }


        /// <summary>
        /// Limpo o Elemento
        /// </summary>
        /// <param name="by"></param>
        public static void Clear(By by)
        {
            WaitElementIsPresent(by);
            var element = FindElement(by);
            element.Clear();
        }

        public static void PressEnter(By by)
        {
            StepHelper.WaitElementIsPresent(by);

            StepHelper.Attempt(() =>
            {
                var element = FindFirstVisibleElement(by);
                element.SendKeys(Keys.Enter);
                return true;
            });
        }

        public static void PressTab(By by)
        {
            StepHelper.WaitElementIsPresent(by);
            var element = FindElement(by);

            element.SendKeys(Keys.Tab);
        }

        public static void Log(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
                message = message.Replace("{", "{{").Replace("}", "}}");

            LogHelper.Log($"{_indentation} {message}", args);
        }

        public static void LogSeparator()
        {
            LogHelper.Log($"############################################################################################################################################");
        }

        public static void LogHighlighted(string message, params object[] args)
        {
            LogHelper.Log($"{_indentation} [{message}]", args);
        }

        public static void LogNewLine()
        {
            StepHelper.Log(string.Empty);
        }

        private static string _indentation;
        public static void Indent()
        {
            _indentation += "#";
        }

        public static void Undent()
        {
            if (_indentation.Length > 0)
                _indentation = _indentation.Substring(0, _indentation.Length - 1);
        }

        public static string GetText(By by, int attempts = 10)
        {
            string text = null;

            Attempt(() =>
            {
                text = FindElement(by).Text;
                return true;
            }, attempts);

            return text;
        }
        #endregion

        #region Helpers
        public static IWebElement FindFirstVisibleElement(By by)
        {
            return by.FindElements(Driver).FirstOrDefault(e => e.Displayed);
        }
        /// <summary>
        /// Executa o comando o número de tentativas especificadas até que não aconteça exceção e que seja retornado true.
        /// </summary>
        /// <param name="command">O comando a ser executado.</param>
        /// <param name="attempts">O número de tentativas.</param>
        public static bool Attempt(Func<bool> command, int attempts = 10, int sleep = 1000)
        {
            if (attempts == 10)
            {
                attempts = RuntimeEnvironment.Current.Attempts;
            }

            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    AttemptBegin?.Invoke(typeof(StepHelper), EventArgs.Empty);

                    if (command())
                    {
                        return true;
                    }
                    else
                    {
                        if (i > AppConfig.LogAttemptsAfter)
                            Log("Attempt {0} of {1} failed. URL: {3}", i + 1, attempts, sleep, Driver.Url);

                        Browser.Current.Renavigate();
                    }

                    Sleep(sleep);
                }
                catch (TimeoutException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("binding error:"))
                    {
                        break;
                    }

                    if (i > AppConfig.LogAttemptsAfter)
                        Log("Attempt {0} of {1} failed with exception: {2}: {3}", i + 1, attempts, ex.Message, command.Method.Name);
                    
                    Sleep(sleep);
                    continue;
                }
            }

            return command();           
        }

        public static void Sleep(int milliseconds, string reason = null)
        {
            var remaining = milliseconds;

            if (RuntimeEnvironment.Current.UseDatabasePingAsSleep)
            {
                remaining -= Database.Ping();
            }

            if (remaining > 0)
            {
                if (!String.IsNullOrEmpty(reason))
                    Log("Sleep {0}: {1}", remaining, reason);

                Thread.Sleep(Convert.ToInt32(remaining));
            }
        }

        public static void Wait(string reason)
        {
            Sleep(RuntimeEnvironment.Current.WaitMilliseconds, reason);
        }

        public static void WaitByBrowser(string reason)
        {
            Sleep(Browser.Current.WaitMilliseconds, reason);
        }
        #endregion

        private static Regex _getCmdRegex = new Regex(@"\s+(?<cmd>\S+) (?<expression>.+)\r*", RegexOptions.Compiled);
        public static void Run(this StepsBase step, string scenario)
        {
            var lines = scenario.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var lastCmd = string.Empty;

            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                    continue;

                var match = _getCmdRegex.Match(line);

                if (!match.Success)
                {
                    Log($"'{line}' is an invalid expression.");
                    continue;
                }

                var cmd = match.Groups["cmd"].Value.ToUpperInvariant();
                var expression = match.Groups["expression"].Value;

                if (cmd == "E")
                    cmd = lastCmd;

                switch (cmd)
                {
                    case "QUANDO":
                        step.When(expression);
                        break;

                    case "ENTÃO":
                        step.Then(expression);
                        break;
                }

                lastCmd = cmd;
            }
        }

        #endregion
    }
}
