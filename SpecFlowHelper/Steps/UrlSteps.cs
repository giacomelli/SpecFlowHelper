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
            string baseUrl;
            string partialUrl;

            if (relativeUrl.StartsWith("http", System.StringComparison.OrdinalIgnoreCase))
            {
                baseUrl = relativeUrl;
                partialUrl = "";
            }
            else
            {
                baseUrl = StepHelper.BaseURL;
                partialUrl = relativeUrl;
            }

            var urlOpeningArgs = new UrlOpeningEventArgs(Driver, baseUrl, partialUrl);
            ExecutionEvents.RaiseUrlOpening(urlOpeningArgs);

            var fullUrl = AppConfig.UrlFormat.With(urlOpeningArgs.BaseUrl, urlOpeningArgs.RelativeUrl);
            Driver.Navigate().GoToUrl(fullUrl);

            var urlOpenedArgs = new UrlOpenedEventArgs(Driver, baseUrl, partialUrl);
            ExecutionEvents.RaiseUrlOpened(urlOpenedArgs);
        }

        [Then(@"a url atual é '(.*)'")]
        public void EntaoAUrlAtualE(string url)
        {
            AssertHelper.AssertUrlEquals(url);
        }
    }
}
