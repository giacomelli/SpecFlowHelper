using System;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    [Binding]
    public class GridSteps : StepsBase
    {
        #region Finders
        public static Func<GridSteps, By> RowFinder = (s) => By.CssSelector(".ui-grid-row");
        public static Func<GridSteps, int, By> RowByNumberFinder = (s, rowNumber) => By.CssSelector(".ui-grid-row:nth-child({0})".With(rowNumber));
        public static Func<GridSteps, string, By> RowByTextFinder = (s, text) => By.XPath("//*[contains(@class,'ui-grid-cell-contents') and contains(node(),'{0}')]".With(text));
        public static Func<GridSteps, string, By> RowRemoveButtonByTextFinder = (s, text) => By.XPath("//*[contains(@class,'ui-grid-cell-contents') and contains(node(),'{0}')]".With(text));
        public static Func<GridSteps, By> NextPageFinder = (s) => s.ByNgClick("paginationApi.nextPage()");
        public static Func<GridSteps, By> LastPageFinder = (s) => s.ByNgClick("paginationApi.seek(paginationApi.getTotalPages())");
        #endregion

        #region Steps
        [Then(@"a grid deve ter '(.*)' linhas")]
        public void EntaoAGridDeveTerLinhas(int rows)
        {
            StepHelper.Attempt(() =>
            {
                var elements = StepHelper.Driver.FindElements(RowFinder(this));

                Assert.AreEqual(rows, elements.Count, "A grid deveria ter {0} linhas".With(rows));

                return true;
            });
        }

        [When(@"clico na primeira linha da grid")]
        public void QuandoClicoNaPrimeiraLinhaDaGrid()
        {
            StepHelper.Click(RowFinder(this));
        }

        [When(@"clico na linha '(.*)' da grid")]
        public void QuandoClicoNaLinhaDaGrid(int row)
        {
            StepHelper.Click(RowByNumberFinder(this, row));
        }

        [When(@"pagino a grid para a próxima página")]
        public void QuandoPaginoAGridParaAProximaPagina()
        {
            StepHelper.Click(NextPageFinder(this));
        }

        [When(@"pagino a grid para a última página")]
        public void QuandoPaginoAGridParaAUltimaPagina()
        {
            StepHelper.Click(LastPageFinder(this));
        }

        [When(@"clico na linha da grid com o texto '(.*)'")]
        public void QuandoClicoNaLinhaDaGridComOTexto(string text)
        {
            var by = RowByTextFinder(this, text);

            StepHelper.Click(by);
        }

        [When(@"clico no botão excluir na linha da grid com o texto '(.*)'")]
        public void QuandoClicoNoBotaoExcluirNaLinhaDaGridComOTexto(string text)
        {
            var by = RowRemoveButtonByTextFinder(this, text);

            StepHelper.Click(by);
        }

        #endregion
    }
}
