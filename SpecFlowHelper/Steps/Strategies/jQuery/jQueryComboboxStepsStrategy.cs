using OpenQA.Selenium;
using SpecFlowHelper.Steps.Strategies.AngularJS;

namespace SpecFlowHelper.Steps.Strategies.jQuery
{
    /// <summary>
    /// jQuery combobox steps strategy.
    /// </summary>
    public class jQueryComboboxStepsStrategy : AngularJSComboboxStepsStrategy
    {
        #region Methods
        /// <summary>
        /// Whens the type enter in the combobox with search.
        /// </summary>
        /// <param name="field">The field.</param>
        public override void WhenTypeEnterInTheComboboxWithSearch(string field)
        {
            var by = By.CssSelector(".select2-input");

            CurrentSteps.Input(by).PressEnter();
        }

        /// <summary>
        /// Thens the combobox should have text selected.
        /// </summary>        
        /// <param name="field">The field.</param>
        /// /// <param name="text">The text.</param>
        public override void ThenTheComboboxShouldHaveTextSelected(string field, string text)
        {
            var by = By.Id(field);

            AssertHelper.AssertDropdownItem(text, by);
        }

        /// <summary>
        /// Whens the select in the combobox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="field">The selected identifier.</param>
        public override void WhenSelectInTheCombobox(string text, string field)
        {
            var by = By.Id(field);

            StepHelper.SelectDropdownItem(by, text);
        }
        #endregion
    }
}
