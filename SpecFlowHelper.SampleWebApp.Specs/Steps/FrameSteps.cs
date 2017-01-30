using SpecFlowHelper.Steps;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.SampleWebApp.Specs.Steps
{
    [Binding]
    public class FrameSteps : StepsBase
    {
        [When(@"navego para o iframe '(.*)'")]
        public void QuandoNavegoParaOIframe(string iframe)
        {
            StepHelper.NavigateToIframeWithSrc(iframe);
        }

        [When(@"navego de volta para a janela principal")]
        public void QuandoNavegoDeVoltaParaAJanelaPrincipal()
        {
            StepHelper.NavigateBackToMainWindow();
        }

    }
}
