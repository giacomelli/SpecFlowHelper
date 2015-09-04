using HelperSharp;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations;
using SpecFlowHelper.Steps;
using TechTalk.SpecFlow;

namespace SpecFlowHelper
{
    [Binding]
    public class UrlSteps : StepsBase
    {
        [When(@"acesso a página principal")]
        public void QuandoAcessoAPaginaPrincipal()
        {
            if (!Driver.Url.Equals(StepHelper.BaseURL))
            {
                Driver.Navigate().GoToUrl(StepHelper.BaseURL);
            }
        }

        [Then(@"abro a url '(.*)'")]
        [When(@"abro a url '(.*)'")]
        public void EntaoAbroAUrl(string relativeUrl)
        {
            var urlOpeningEventArgs = new UrlOpeningEventArgs(StepHelper.BaseURL, relativeUrl);
            var fullUrl = AppConfig.UrlFormat.With(urlOpeningEventArgs.BaseUrl, urlOpeningEventArgs.RelativeUrl);

            Driver.Navigate().GoToUrl(fullUrl);
        }

        [Then(@"a url atual é '(.*)'")]
        public void EntaoAUrlAtualE(string url)
        {
            AssertHelper.AssertUrlEquals(url);
        }
    }
}
