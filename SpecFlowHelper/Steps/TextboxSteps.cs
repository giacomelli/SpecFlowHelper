using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class TextboxSteps : StepsBase
    {
        private ITextboxStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<ITextboxStepsStrategy, TextboxSteps>(this);
            }
        }
        [When(@"digito '(.*)' no campo '(.*)'")]
        public void QuandoDigitoNoCampo(string value, string field)
        {
            Strategy.WhenTypeOnTheField(value, field);
        }

        [Then(@"o campo '(.*)' deve ter o valor '(.*)'")]
        public void EntaoOCampoDeveTerOValor(string field, string value)
        {
            Strategy.ThenTheFieldShouldHaveTheValue(field, value);
        }

        [When(@"teclo enter o campo '(.*)'")]
        public void QuandoTecloEnterOCampo(string field)
        {
            Strategy.WhenTypeEnterOnTheField(field);
        }

        [When(@"teclo enter no elemento '(.*)'")]
        public void QuandoTecloEnterNoElemento(string field)
        {
            Strategy.WhenTypeEnterOnTheElement(field);
        } 
    }
}
