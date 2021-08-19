using System;
using System.Diagnostics;
using System.Threading;
using HelperSharp;
using NUnit.Framework;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

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
        private static StepDefinitionType? _previousStepType;

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
            
            var step = ScenarioStepContext.Current.StepInfo;
            var currentStepType = step.StepDefinitionType;

            var stepTypeTranslated = _previousStepType.HasValue && _previousStepType.Value == currentStepType
                ? "E"
                : Translate(currentStepType);

            _previousStepType = currentStepType;

            StepHelper.Log($"{stepTypeTranslated} {step.Text}");
        }

        private static void CheckTimeout()
        {
            if (s_scenarioStopwatch.Elapsed >= AppConfig.ScenarioTimeout)
            {                
                StepHelper.ThrowScenarioTimeout();
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
            StepHelper.Log("ELAPSED: {0} seconds".With(s_testStopwatch.Elapsed.TotalSeconds));
            StepHelper.Quit();
        }

        [BeforeFeature]
        public static void RunBeforeFeature()
        {
            s_featureStopwatch.Restart();
            var title = FeatureContext.Current.FeatureInfo.Title;
            StepHelper.Indent();
            StepHelper.Log("FEATURE BEGIN: {0}", title);
        }

        [AfterFeature]
        public static void RunAfterFeature()
        {
            s_featureStopwatch.Stop();
            StepHelper.Log("ELAPSED: {0} seconds".With(s_featureStopwatch.Elapsed.TotalSeconds));
            StepHelper.Undent();
        }

        [BeforeScenario]
        public static void RunBeforeScenario()
        {
            _previousStepType = null;
            s_scenarioStopwatch.Restart();
            ValidateState();
            var info = ScenarioContext.Current.ScenarioInfo;

            StepHelper.LogNewLine();
            StepHelper.Indent();
            StepHelper.LogSeparator();
            StepHelper.Log($"SCENARIO BEGIN: {info.Title}");
            StepHelper.Log($"TAGS: {String.Join(", ", FeatureContext.Current.FeatureInfo.Tags)}");
            StepHelper.RaiseScenarioBegin();
        }

        [AfterScenario]
        public static void RunAfterScenario()
        {
            Thread.Sleep(2000);

            var scenario = ScenarioContext.Current;
            var info = scenario.ScenarioInfo;
            var status = scenario.TestError == null ? "success" : "error {0}{1}".With(Environment.NewLine, scenario.TestError.Message);

            if (scenario.TestError == null)
            {
                if (scenario.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
                {
                    status = scenario.ScenarioExecutionStatus.ToString();
                    StepHelper.RaiseErrorOcurred(new InvalidOperationException("Scenario ended with error"));                    
                }
            }
            else
                StepHelper.RaiseErrorOcurred(new InvalidOperationException("Scenario ended with error"));
                

            StepHelper.Log($"SCENARIO END: {info.Title}");
            StepHelper.Log($"STATUS: {status}");
            StepHelper.Log($"TAGS: {String.Join(", ", FeatureContext.Current.FeatureInfo.Tags)}");
            StepHelper.Log($"ELAPSED: {s_scenarioStopwatch.Elapsed.TotalSeconds} seconds");            

            if (status.Equals("success"))
            {
                s_scenarioSuccessCount++;
            }
            else
            {
                s_scenarioErrorCount++;
            }

            StepHelper.Log("SCENARIOS: {0} SUCCESS AND {1} ERROR", s_scenarioSuccessCount, s_scenarioErrorCount);
            StepHelper.LogSeparator();
            StepHelper.Undent();
            StepHelper.LogNewLine();

            s_scenarioStopwatch.Stop();

            if(scenario.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
                scenario.Pending();
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

        private static string Translate(StepDefinitionType stepType)
        {
            switch(stepType)
            {
                case StepDefinitionType.Given:
                    return "Dado";

                case StepDefinitionType.Then:
                    return "Então";

                default:
                    return "Quando";
            }
        }
    }
}