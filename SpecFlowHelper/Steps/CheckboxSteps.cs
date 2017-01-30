using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// Checkbox steps.
    /// </summary>
    [Binding]
    public sealed class CheckboxSteps : StepsBase
    {
        #region Properties
        private ICheckboxStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<ICheckboxStepsStrategy, CheckboxSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When check the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        [When(Locale.WhenCheckTheCheckbox)]
        public void WhenCheckTheCheckbox(string checkbox)
        {
            Strategy.WhenCheckTheCheckbox(checkbox);
        }

        /// <summary>
        /// Whens uncheck the checkbox.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        [When(Locale.WhenUncheckTheCheckbox)]
        public void WhenUncheckTheCheckbox(string checkbox)
        {
            Strategy.WhenUncheckTheCheckbox(checkbox);
        }
        #endregion
    }
}
