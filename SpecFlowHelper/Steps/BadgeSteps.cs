using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class BadgeSteps : StepsBase
    {
        [Then(@"deve exibir o badge com o texto '(.*)'")]
        public void EntaoDeveExibirOBadgeComOTexto(string text)
        {
            var by = By.CssSelector(".badge");

            AssertHelper.AssertTextAreEqual(text, by);
        }
    }
}
