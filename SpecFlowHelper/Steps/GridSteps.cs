using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Grid steps.
    /// </summary>
    [Binding]
    public class GridSteps : StepsBase
    {
        #region Properties
        private IGridStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IGridStepsStrategy, GridSteps>(this);
            }
        }
        #endregion

        #region Methods
        [Then(Locale.ThenTheGridShouldHaveRows)]
        public void ThenTheGridShouldHaveRows(int rows)
        {
            Strategy.ThenTheGridShouldHaveRows(rows);
        }

        [When(Locale.WhenClickInTheFirstGridRow)]
        public void WhenClickInTheFirstGridRow()
        {
            Strategy.WhenClickInTheFirstGridRow();
        }

        [When(Locale.WhenClickInTheGridRow)]
        public void WhenClickInTheGridRow(int row)
        {
            Strategy.WhenClickInTheGridRow(row);
        }

        [When(Locale.WhenPaginateToTheNextGridPage)]
        public void WhenPaginateToTheNextGridPage()
        {
            Strategy.WhenPaginateToTheNextGridPage();
        }

        [When(Locale.WhenPaginateToThePreviousGridPage)]
        public void WhenPaginateToThePreviousGridPage()
        {
            Strategy.WhenPaginateToThePreviousGridPage();
        }

        [When(Locale.WhenPaginateToLastGridPage)]
        public void WhenPaginateToLastGridPage()
        {
            Strategy.WhenPaginateToLastGridPage();
        }

        [When(Locale.WhenPaginateToFirstGridPage)]
        public void WhenPaginateToFirstGridPage()
        {
            Strategy.WhenPaginateToFirstGridPage();
        }

        [When(Locale.WhenClickInTheGridRowWithTheText)]
        public void WhenClickInTheGridRowWithTheText(string text)
        {
            Strategy.WhenClickInTheGridRowWithTheText(text);
        }

        [When(Locale.WhenClickInTheRemoveButtonInTheGridRowWithTheText)]
        public void WhenClickInTheRemoveButtonInTheGridRowWithTheText(string text)
        {
            Strategy.WhenClickInTheRemoveButtonInTheGridRowWithTheText(text);
        }

        [When(Locale.WhenSortTheGridByColumn)]
        public void WhenSortTheGridByColumn(string columnTitle)
        {
            Strategy.WhenSortTheGridByColumn(columnTitle);
        }
        #endregion
    }
}
