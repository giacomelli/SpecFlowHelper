namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for grid steps strategies.
    /// </summary>
    public interface IGridStepsStrategy : IStepsStrategy<GridSteps>
    {
        /// <summary>
        /// Then the grid should have rows.
        /// </summary>
        /// <param name="rows">The rows.</param>
        void ThenTheGridShouldHaveRows(int rows);

        /// <summary>
        /// When click in the first grid row.
        /// </summary>
        void WhenClickInTheFirstGridRow();

        /// <summary>
        /// When click in the grid row.
        /// </summary>
        /// <param name="row">The row.</param>
        void WhenClickInTheGridRow(int row);

        /// <summary>
        /// When paginate to the next grid page.
        /// </summary>
        void WhenPaginateToTheNextGridPage();

        /// <summary>
        /// When paginate to the previous grid page.
        /// </summary>
        void WhenPaginateToThePreviousGridPage();

        /// <summary>
        /// When paginate to last grid page.
        /// </summary>
        void WhenPaginateToLastGridPage();

        /// <summary>
        /// When paginate to first grid page.
        /// </summary>
        void WhenPaginateToFirstGridPage();

        /// <summary>
        /// When click in the grid row with the text.
        /// </summary>
        /// <param name="text">The text.</param>
        void WhenClickInTheGridRowWithTheText(string text);

        /// <summary>
        /// When click in the remove button in the grid row with the text.
        /// </summary>
        /// <param name="text">The text.</param>
        void WhenClickInTheRemoveButtonInTheGridRowWithTheText(string text);

        /// <summary>
        /// Whens sort the grid by column.
        /// </summary>
        /// <param name="columnTitle">The column title.</param>
        void WhenSortTheGridByColumn(string columnTitle);
    }
}
