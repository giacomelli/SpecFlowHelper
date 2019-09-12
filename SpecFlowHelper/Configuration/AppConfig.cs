using System;
using System.Net;
using HelperSharp;
using SpecFlowHelper.Integrations.Browsers;
using SpecFlowHelper.Integrations.Environments;
using TestSharp;

namespace SpecFlowHelper.Configuration
{    
    public static class AppConfig
    {        
        public static BrowserKind BrowserKind = BrowserKind.IE;
        public static string BrowserDriverFolder;

        /// <summary>
        /// The URL format: BaseUrl + RelativeUrl.
        /// </summary>
        /// <example>
        /// If you are using AngularJs, de UrlFormat will be: "{0}/#/{1}".
        /// </example>
        public static string UrlFormat = "{0}/{1}";

        public static string UploadFilesFolder;

        public static IEnvironment Environment = new DevelopmentEnvironment();
        public static string Configuration;
        
        public static WebProjectConfig[] WebProjects = new WebProjectConfig[0];
        public static IBaseUrlSolver BaseUrlSolver = new DefaultBaseUrlSolver();

        public static bool JobsEnabled = false;
        public static string JobsEnabledInfo = "default configuration";
        public static string JobsProjectFolderName;
        public static string JobsProcessName;
        public static string JobsLogFileName;

        public static bool InitializeDBEnabled = false;

        public static TimeSpan ScenarioTimeout = TimeSpan.FromMinutes(5);
        public static int LogAttemptsAfter = 4;

        public static bool AutoQuitBrowser = true;

        public static void Validate()
        {
            ValidateString("Configuration", Configuration);
            ValidateString("BrowserDriverFolder", BrowserDriverFolder);

            foreach(var webProject in WebProjects)
            {
                ValidateString(nameof(WebProjectConfig.FolderName), webProject.FolderName);
                ValidateProjectFolder(nameof(WebProjectConfig.FolderName), webProject.FolderName);
                ValidateInt("Port", webProject.Port);
            }

            if (JobsEnabled)
            {
                ValidateString("JobsProjectFolderName", JobsProjectFolderName);
                ValidateString("JobsProcessName", JobsProcessName);
                ValidateString("JobsLogFileName", JobsLogFileName);
            }
        }

        private static void ValidateProjectFolder(string propertyName, string propertyValue)
        {
            if (String.IsNullOrEmpty(VSProjectHelper.GetProjectFolderPath(propertyValue)))
            {
                throw new InvalidOperationException("AppConfig.{0} is wroing: cannot find a project with folder '{1}'.".With(propertyName, propertyValue));
            }
        }

        private static void ValidateString(string propertyName, string propertyValue)
        {
            if (String.IsNullOrEmpty(propertyValue))
            {
                throw new InvalidOperationException("Configure AppConfig.{0} before run SpecFlow.".With(propertyName));
            }
        }

        private static void ValidateInt(string propertyName, int propertyValue)
        {
            if (propertyValue == 0)
            {
                throw new InvalidOperationException("Configure AppConfig.{0} before run SpecFlow.".With(propertyName));
            }
        }
    }
}
