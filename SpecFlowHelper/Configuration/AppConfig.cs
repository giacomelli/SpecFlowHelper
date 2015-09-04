﻿using System;
using HelperSharp;
using SpecFlowHelper.Integrations.Browsers;
using SpecFlowHelper.Integrations.Environments;

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

        public static bool WebApiEnabled = true;
        public static string WebApiProjectFolderName;
        public static int WebApiPort;

        public static string WebAppProjectFolderName;
        public static int WebAppPort;
        public static string WebAppBaseUrl;

        public static bool JobsEnabled = true;
        public static string JobsProjectFolderName;
        public static string JobsProcessName;
        public static string JobsLogFileName;

        public static bool InitializeDBEnabled = false;

        public static void Validate()
        {
            ValidateString("Configuration", Configuration);
            ValidateString("BrowserDriverFolder", BrowserDriverFolder);

            if (WebApiEnabled)
            {
                ValidateString("WebApiProjectFolderName", WebApiProjectFolderName);
                ValidateInt("WebApiPort", WebApiPort);
            }

            ValidateString("WebAppProjectFolderName", WebAppProjectFolderName);
            ValidateInt("WebAppPort", WebAppPort);
            ValidateString("WebAppBaseUrl", WebAppBaseUrl);

            if (JobsEnabled)
            {
                ValidateString("JobsProjectFolderName", JobsProjectFolderName);
                ValidateString("JobsProcessName", JobsProcessName);
                ValidateString("JobsLogFileName", JobsLogFileName);
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
