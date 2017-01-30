namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// Defines the interface for combobox steps strategies.
    /// </summary>
    public interface IComboboxStepsStrategy : IStepsStrategy<ComboboxSteps>
    {
        /// <summary>
        /// When type in the combobox with search.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="field">The field.</param>
        void WhenTypeInTheComboboxWithSearch(string value, string field);

        /// <summary>
        /// When type enter in the combobox with search.
        /// </summary>
        /// <param name="field">The field.</param>
        void WhenTypeEnterInTheComboboxWithSearch(string field);

        /// <summary>
        /// Then the combobox with search should have texts selected.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="texts">The texts.</param>
        void ThenTheComboboxWithSearchShouldHaveTextsSelected(string field, string texts);

        /// <summary>
        /// When remove the item from combobox with search.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="field">The field.</param>
        void WhenRemoveTheItemFromComboboxWithSearch(string item, string field);

        /// <summary>
        /// Then the combobox should have text selected.
        /// </summary>
        /// <param name="field">The selected identifier.</param>
        /// <param name="text">The text.</param>
        void ThenTheComboboxShouldHaveTextSelected(string field, string text);

        /// <summary>
        /// When select in the combobox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="field">The field.</param>
        void WhenSelectInTheCombobox(string text, string field);
    }
}
