using System;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class PageSteps : StepsBase
    {
        [Then(@"deve exibir o dia atual no formato dd/MM/yyyy")]
        public void EntaoDeveExibirODiaAtualNoFormatoDdMMYyyy()
        {
            AssertHelper.AssertTextExists(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        [Then(@"deve exibir o texto '(.*)'")]
        [Then(@"deve exibir a mensagem '(.*)'")]
        public void EntaoDeveExibirAMensagem(string text)
        {
            AssertHelper.AssertTextExists(text);
        }

        [Then(@"deve exibir os textos '(.*)'")]
        [Then(@"deve exibir as mensagens '(.*)'")]
        public void EntaoDeveExibirAsMensagens(string texts)
        {
            var textsSplit = texts.Split(';');

            for (int i = 0; i < textsSplit.Length; i++)
            {
                EntaoDeveExibirAMensagem(textsSplit[i]);
            }
        }

        [Then(@"não deve exibir o texto '(.*)'")]
        [Then(@"não deve exibir a mensagem '(.*)'")]
        public void EntaoNaoDeveExibirAMensagem(string text)
        {
            AssertHelper.AssertTextNotExists(text);
        }


    }
}
