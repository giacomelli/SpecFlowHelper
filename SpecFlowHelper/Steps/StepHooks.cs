using System;
using System.Diagnostics;
using System.Threading;
using HelperSharp;
using OpenQA.Selenium;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using SpecFlowHelper.Integrations.Browsers;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public static class StepHooks
    {
        private static int s_scenarioSuccessCount;
        private static int s_scenarioErrorCount;
        private static Stopwatch s_testStopwatch = new Stopwatch();
        private static Stopwatch s_featureStopwatch = new Stopwatch();
        private static Stopwatch s_scenarioStopwatch = new Stopwatch();
        private static bool s_shouldAbort;

        static StepHooks ()
        {
            StepHelper.AttemptBegin += (s, e) =>
            {
                CheckTimeout();
            };
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            CheckTimeout();
        }

        private static void CheckTimeout()
        {
            if (s_scenarioStopwatch.Elapsed >= AppConfig.ScenarioTimeout)
            {
                throw new TimeoutException("ScenarioTimeout reach: {0}".With(AppConfig.ScenarioTimeout));
            }
        }

        public static void RunOneTimeForFeature(string name, Action action)
        {
            if (!FeatureContext.Current.ContainsKey(name))
            {
                action();
                FeatureContext.Current[name] = true;
            }
        }

        [BeforeTestRun]
        public static void RunBerforTest()
        {
            s_testStopwatch.Restart();

            s_scenarioSuccessCount = 0;
            s_scenarioErrorCount = 0;
            StepHelper.InitializeDriver();
        }

        [AfterTestRun]
        public static void RunAfterTest()
        {
            s_testStopwatch.Stop();
            StepHelper.Log("##### TEST RUN IN: {0} SECONDS".With(s_testStopwatch.Elapsed.TotalSeconds));
            StepHelper.Quit();
        }

        [BeforeFeature]
        public static void RunBeforeFeature()
        {
            s_featureStopwatch.Restart();
            var title = FeatureContext.Current.FeatureInfo.Title;
            StepHelper.Log("##### FEATURE BEGIN: \"{0}\"", title);
        }

        [AfterFeature]
        public static void RunAfterFeature()
        {
            s_featureStopwatch.Stop();
            StepHelper.Log("##### FEATURE RUN IN: {0} SECONDS".With(s_featureStopwatch.Elapsed.TotalSeconds));
        }

        [BeforeScenario]
        public static void RunBeforeScenario()
        {
            s_scenarioStopwatch.Restart();
            ValidateState();
            var title = ScenarioContext.Current.ScenarioInfo.Title;
            StepHelper.Log("##### SCENARIO BEGIN: \"{0}\"", title);

            // Writes to browser window.
            if (Browser.Current.Kind != BrowserKind.IE)
            {
                StepHelper.Driver.Navigate().GoToUrl("data:text/html, <html><title>SpecFlowHelper</title><body contenteditable style='font-size:48pt;text-align:center;'>");
                StepHelper.EnterValue(By.TagName("body"), title);
            }
        }

        [AfterScenario]
        public static void RunAfterScenario()
        {
            Thread.Sleep(2000);

            var scenario = ScenarioContext.Current;
            var title = ScenarioContext.Current.ScenarioInfo.Title;
            var status = scenario.TestError == null ? "success" : "error {0}{1}".With(Environment.NewLine, scenario.TestError.Message);
            StepHelper.Log("##### SCENARIO END: \"{0}\". Status: {1}", title, status);
            StepHelper.Log("##### SCENARIO RUN IN: {0} SECONDS".With(s_scenarioStopwatch.Elapsed.TotalSeconds));

            if (status.Equals("success"))
            {
                s_scenarioSuccessCount++;
            }
            else
            {
                s_scenarioErrorCount++;
            }

            StepHelper.Log("##### SCENARIOS: {0} SUCCESS AND {1} ERROR", s_scenarioSuccessCount, s_scenarioErrorCount);

            s_scenarioStopwatch.Stop();
        }        

        public static void Abort()
        {
            s_shouldAbort = true;
        }

        private static void ValidateState()
        {
            if (s_shouldAbort || (s_scenarioErrorCount > 0 && RuntimeEnvironment.Current.ShouldAbortOnFirstTestError))
            {
                throw new InvalidOperationException("Aborting tests because a previous test as failed.");
            }
        }
    }
}