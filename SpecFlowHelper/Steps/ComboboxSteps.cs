using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// The combobox steps.
    /// </summary>
    [Binding]
    public class ComboboxSteps : StepsBase
    {
        public IComboboxStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IComboboxStepsStrategy, ComboboxSteps>(this);
            }
        }

        #region Steps
        [When(Locale.WhenTypeInTheComboboxWithSearch)]
        public void WhenTypeInTheComboboxWithSearch(string value, string field)
        {
            Strategy.WhenTypeInTheComboboxWithSearch(value, field);
        }

        [When(Locale.WhenTypeEnterInTheComboboxWithSearch)]
        public void WhenTypeEnterInTheComboboxWithSearch(string field)
        {
            Strategy.WhenTypeEnterInTheComboboxWithSearch(field);
        }

        [Then(Locale.ThenTheComboboxWithSearchShouldHaveTextsSelected)]
        public void ThenTheComboboxWithSearchShouldHaveTextsSelected(string field, string texts)
        {
            Strategy.ThenTheComboboxWithSearchShouldHaveTextsSelected(field, texts);
        }

        [When(Locale.WhenRemoveTheItemFromComboboxWithSearch)]
        public void WhenRemoveTheItemFromComboboxWithSearch(string item, string field)
        {
            Strategy.WhenRemoveTheItemFromComboboxWithSearch(item, field);
        }

        [Then(Locale.ThenTheComboboxShouldHaveTextSelected)]
        public void ThenTheComboboxShouldHaveTextSelected(string field, string text)
        {
            Strategy.ThenTheComboboxShouldHaveTextSelected(field, text);
        }

        [When(Locale.WhenSelectInTheCombobox)]
        public void WhenSelectInTheCombobox(string text, string field)
        {
            Strategy.WhenSelectInTheCombobox(text, field);
        }
        #endregion
    }
}
