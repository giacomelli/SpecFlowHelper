using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class ToastSteps : StepsBase
    {
        [Then(@"deve exibir o toast '(.*)'")]
        public void EntaoDeveExibirOToast(string message)
        {
            StepHelper.Attempt(() =>
            {
                var toastMessage = this.Toast().Message;
                Assert.AreEqual(message, toastMessage, "A mensagem esperada no toast era: {0}, mas foi {1}".With(message, toastMessage));

                return true;
            });
        }

        [Then(@"então fecho o toast")]
        public void EntaoFechoOToast()
        {
            StepHelper.Attempt(() =>
            {
                var toast = this.Toast();

                if (StepHelper.IsElementPresent(toast.By))
                {
                    toast.Click(1);

                    if (StepHelper.IsElementPresent(toast.By))
                    {
                        toast.Click(1);
                    }
                }

                return true;
            });
        }
    }
}
