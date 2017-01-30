using SpecFlowHelper.Steps.Localization;
using SpecFlowHelper.Steps.Strategies;
using TechTalk.SpecFlow;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// RadioButton steps.
    /// </summary>
    [Binding]
    public sealed class RadioButtonSteps : StepsBase
    {
        #region Properties
        private IRadioButtonStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IRadioButtonStepsStrategy, RadioButtonSteps>(this);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When check the radio button.
        /// </summary>
        /// <param name="radioButton">The radio button.</param>
        [When(Locale.WhenCheckTheRadioButton)]
        public void WhenCheckTheRadioButton(string radioButton)
        {
            Strategy.WhenCheckTheRadioButton(radioButton);
        }
        #endregion
    }
}
