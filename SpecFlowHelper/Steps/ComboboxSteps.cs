using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Combobox steps.
    /// </summary>
    [Binding]
    public class ComboboxSteps : StepsBase
    {
        #region Properties
        private IComboboxStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IComboboxStepsStrategy, ComboboxSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When type in the combobox with search.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="field">The field.</param>
        [When(Locale.WhenTypeInTheComboboxWithSearch)]
        public void WhenTypeInTheComboboxWithSearch(string value, string field)
        {
            Strategy.WhenTypeInTheComboboxWithSearch(value, field);
        }

        /// <summary>
        /// When type enter in the combobox with search.
        /// </summary>
        /// <param name="field">The field.</param>
        [When(Locale.WhenTypeEnterInTheComboboxWithSearch)]
        public void WhenTypeEnterInTheComboboxWithSearch(string field)
        {
            Strategy.WhenTypeEnterInTheComboboxWithSearch(field);
        }

        /// <summary>
        /// Then the combobox with search should have texts selected.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="texts">The texts.</param>
        [Then(Locale.ThenTheComboboxWithSearchShouldHaveTextsSelected)]
        public void ThenTheComboboxWithSearchShouldHaveTextsSelected(string field, string texts)
        {
            Strategy.ThenTheComboboxWithSearchShouldHaveTextsSelected(field, texts);
        }

        /// <summary>
        /// When remove the item from combobox with search.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="field">The field.</param>
        [When(Locale.WhenRemoveTheItemFromComboboxWithSearch)]
        public void WhenRemoveTheItemFromComboboxWithSearch(string item, string field)
        {
            Strategy.WhenRemoveTheItemFromComboboxWithSearch(item, field);
        }

        /// <summary>
        /// Then the combobox should have text selected.
        /// </summary>
        /// <param name="field">The selected identifier.</param>
        /// <param name="text">The text.</param>
        [Then(Locale.ThenTheComboboxShouldHaveTextSelected)]
        public void ThenTheComboboxShouldHaveTextSelected(string field, string text)
        {
            Strategy.ThenTheComboboxShouldHaveTextSelected(field, text);
        }

        /// <summary>
        /// When select in the combobox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="field">The field.</param>
        [When(Locale.WhenSelectInTheCombobox)]
        public void WhenSelectInTheCombobox(string text, string field)
        {
            Strategy.WhenSelectInTheCombobox(text, field);
        }
        #endregion
    }
}
