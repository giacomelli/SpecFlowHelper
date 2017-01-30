using System;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.AngularJS
{
    public class AngularJSDatatablesGridStepsStrategy : StepsStrategyBase<GridSteps>, IGridStepsStrategy
    {
        #region Finders
        protected virtual By GetRowFinder(GridSteps s)
        {
            return By.CssSelector(".ui-grid-row");
        }

        protected virtual By GetRowByNumberFinder(GridSteps s, int rowNumber)
        {
            return By.CssSelector(".ui-grid-row:nth-child({0})".With(rowNumber));
        }

        protected virtual By GetRowByTextFinder(GridSteps s, string text)
        {
            return By.XPath("//*[contains(@class,'ui-grid-cell-contents') and contains(node(),'{0}')]".With(text));
        }

        protected virtual By GetRowRemoveButtonByTextFinder(GridSteps s, string text)
        {
            return By.XPath("//*[contains(@class,'ui-grid-cell-contents') and contains(node(),'{0}')]".With(text));
        }

        protected virtual By GetNextPageFinder(GridSteps s)
        {
            return s.ByNgClick("paginationApi.nextPage()");
        }

        protected virtual By GetPreviousPageFinder(GridSteps s)
        {
            return s.ByNgClick("paginationApi.previousPage()");
        }

        protected virtual By GetLastPageFinder(GridSteps s)
        {
            return s.ByNgClick("paginationApi.seek(paginationApi.getTotalPages())");
        }

        protected virtual By GetFirstPageFinder(GridSteps s)
        {
            return s.ByNgClick("paginationApi.seek(1)");
        }

        protected virtual By GetColumnByTitle(GridSteps s, string columnTitle)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods
        public virtual void ThenTheGridShouldHaveRows(int rows)
        {
            StepHelper.Attempt(() =>
            {
                var elements = StepHelper.Driver.FindElements(GetRowFinder(CurrentSteps));

                Assert.AreEqual(rows, elements.Count, "A grid deveria ter {0} linhas".With(rows));

                return true;
            });
        }

        public virtual void WhenClickInTheFirstGridRow()
        {
            ClickInGridElement(GetRowFinder(CurrentSteps));
        }

        public virtual void WhenClickInTheGridRow(int row)
        {
            ClickInGridElement(GetRowByNumberFinder(CurrentSteps, row));
        }

        public virtual void WhenPaginateToTheNextGridPage()
        {
            ClickInGridElement(GetNextPageFinder(CurrentSteps));
        }

        public virtual void WhenPaginateToThePreviousGridPage()
        {
            ClickInGridElement(GetPreviousPageFinder(CurrentSteps));
        }

        public virtual void WhenPaginateToLastGridPage()
        {
            ClickInGridElement(GetLastPageFinder(CurrentSteps));
        }

        public virtual void WhenPaginateToFirstGridPage()
        {
            ClickInGridElement(GetFirstPageFinder(CurrentSteps));
        }

        public virtual void WhenClickInTheGridRowWithTheText(string text)
        {
            ClickInGridElement(GetRowByTextFinder(CurrentSteps, text));
        }

        public virtual void WhenClickInTheRemoveButtonInTheGridRowWithTheText(string text)
        {
            var by = GetRowRemoveButtonByTextFinder(CurrentSteps, text);
            StepHelper.Click(by);
        }

        public virtual void WhenSortTheGridByColumn(string columnTitle)
        {
            ClickInGridElement(GetColumnByTitle(CurrentSteps, columnTitle));
        }

        private void ClickInGridElement(By by)
        {
            StepHelper.MoveToElement(by);
            StepHelper.Click(by);               
        }
        #endregion
    }
}
