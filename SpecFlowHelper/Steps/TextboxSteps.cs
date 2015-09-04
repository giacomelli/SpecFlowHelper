using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class TextboxSteps : StepsBase
    {
        [When(@"digito '(.*)' no campo '(.*)'")]
        public void QuandoDigitoNoCampo(string value, string field)
        {
            var by = By.XPath("//input[@id='{0}']|//textarea[@id='{0}']|//input[@ng-model='{0}']|//textarea[@ng-model='{0}']".With(field));
            StepHelper.EnterValue(by, value);
        }

        [Then(@"o campo '(.*)' deve ter o valor '(.*)'")]
        public void EntaoOCampoDeveTerOValor(string field, string value)
        {
            var by = By.XPath("//input[@id='{0}']|//textarea[@id='{0}']|//input[@ng-model='{0}']|//textarea[@ng-model='{0}']".With(field));

            StepHelper.Attempt(() =>
            {
                var element = Driver.FindElement(by);
                var inputValue = element.GetAttribute("value");

                Assert.AreEqual(value, inputValue, inputValue);

                return true;
            });
        }


        [When(@"teclo enter o campo '(.*)'")]
        public void QuandoTecloEnterOCampo(string ngModel)
        {
            this.Input(ngModel).PressEnter();
        }

        [When(@"teclo enter no elemento '(.*)'")]
        public void QuandoTecloEnterNoElemento(string ngModel)
        {
            StepHelper.PressEnter(this.ByNgModel(ngModel));
        } 
    }
}
