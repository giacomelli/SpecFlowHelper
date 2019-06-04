using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SpecFlowHelper.Steps;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Configuration
{
    public class TagMapBaseUrlSolver : IBaseUrlSolver
    {
        Dictionary<string, WebProjectConfig> _maps = new Dictionary<string, WebProjectConfig>();

        public TagMapBaseUrlSolver Add(string tag, WebProjectConfig webProject)
        {
            _maps.Add(tag, webProject);
            return this;
        }

        public string Solve(ScenarioContext context, IWebDriver driver)
        {
            var tags = FeatureContext.Current.FeatureInfo.Tags;
            var result = _maps.FirstOrDefault(m => tags.Contains(m.Key));

            if (result.Key == null)
            {
                StepHelper.Log($"TagMapBaseUrlSover did not find a base url for tags: {String.Join(", ", tags)}");
                return string.Empty;
            }

            return result.Value.BaseUrl;                
        }
    }
}
