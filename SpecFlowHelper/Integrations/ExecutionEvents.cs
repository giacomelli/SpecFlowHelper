using System;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// Raise some execution events.
    /// </summary>
    public static class ExecutionEvents
    {
        #region Eventts
        /// <summary>
        /// Occurs when browser is initializing.
        /// </summary>
        public static event EventHandler BrowserInitializing;

        /// <summary>
        /// Occurs when browser is initialized.
        /// </summary>
        public static event EventHandler BrowserInitialized;

        /// <summary>
        /// Occurs when navigated to an IFrame
        /// </summary>
        public static event EventHandler IframeNavigated;

        /// <summary>
        /// Occurs when web driver is initialized.
        /// </summary>
        public static event EventHandler WebDriverInitialized;

        /// <summary>
        /// Occurs when runtime environment is initializing.
        /// </summary>
        public static event EventHandler RuntimeEnvironmentInitializing;

        /// <summary>
        /// Occurs when runtime environment is initialized.
        /// </summary>
        public static event EventHandler RuntimeEnvironmentInitialized;

        /// <summary>
        /// Occurs when database is initializing.
        /// </summary>
        public static event EventHandler DatabaseInitializing;

        /// <summary>
        /// Occurs when database is initialized.
        /// </summary>
        public static event EventHandler DatabaseInitialized;

        /// <summary>
        /// Occurs when element clicking.
        /// </summary>
        public static event EventHandler<ElementClickingEventArgs> ElementClicking;

        /// <summary>
        /// Occurs when URL opening.
        /// </summary>
        public static event EventHandler<UrlOpeningEventArgs> UrlOpening;

        /// <summary>
        /// Occurs when URL is opened.
        /// </summary>
        public static event EventHandler<UrlOpenedEventArgs> UrlOpened;
        #endregion

        #region Methods
        internal static void RaiseBrowserInitializing()
        {
            if (BrowserInitializing != null)
            {
                BrowserInitializing(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseBrowserInitialized()
        {
            if (BrowserInitialized != null)
            {
                BrowserInitialized(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseIframeNavigated()
        {
            if (IframeNavigated != null)
            {
                IframeNavigated(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }


        internal static void RaiseWebDriverInitialized()
        {
            if (WebDriverInitialized != null)
            {
                WebDriverInitialized(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseRuntimeEnvironmentInitializing()
        {
            if (RuntimeEnvironmentInitializing != null)
            {
                RuntimeEnvironmentInitializing(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseRuntimeEnvironmentInitialized()
        {
            if (RuntimeEnvironmentInitialized != null)
            {
                RuntimeEnvironmentInitialized(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseDatabaseInitializing()
        {
            if (DatabaseInitializing != null)
            {
                DatabaseInitializing(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseDatabaseInitialized()
        {
            if (DatabaseInitialized != null)
            {
                DatabaseInitialized(typeof(ExecutionEvents), EventArgs.Empty);
            }
        }

        internal static void RaiseElementClicking(ElementClickingEventArgs args)
        {
            if (args.Element != null && ElementClicking != null)
            {
                ElementClicking(typeof(ExecutionEvents), args);
            }
        }

        internal static void RaiseUrlOpening(UrlOpeningEventArgs args)
        {
            if (UrlOpening != null)
            {
                UrlOpening(typeof(ExecutionEvents), args);
            }
        }

        internal static void RaiseUrlOpened(UrlOpenedEventArgs args)
        {
            if (UrlOpened != null)
            {
                UrlOpened(typeof(ExecutionEvents), args);
            }
        }
        #endregion
    }
}
