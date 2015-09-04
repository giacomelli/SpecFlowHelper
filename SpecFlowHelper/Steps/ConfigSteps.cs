using SpecFlowHelper.Configuration;
using TechTalk.SpecFlow;
using TestSharp;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class ConfigSteps : StepsBase
    {
        [When(@"altero a chave '(.*)' do web\.config para '(.*)'")]
        public void QuandoAlteroAChaveDoWeb_ConfigPara(string key, string value)
        {
            ConfigHelper.WriteAppSetting(AppConfig.WebApiProjectFolderName, key, value);
        }
    }
}
