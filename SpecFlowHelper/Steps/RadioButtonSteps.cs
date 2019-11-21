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
        private IRadioButtonStepsStrategy Strategy
        {
            get
            {
                return StrategyFactory.Create<IRadioButtonStepsStrategy, RadioButtonSteps>(this);
            }
        }
       
        /// <summary>
        /// When check the radio button.
        /// </summary>
        /// <param name="radioButton">The radio button.</param>
        [When(Locale.WhenCheckTheRadioButton)]
        public void WhenCheckTheRadioButton(string radioButton)
        {
            Strategy.WhenCheckTheRadioButton(radioButton);
        }

        /// <summary>
        /// Then the radio button should be read only.
        /// </summary>
        /// <param name="radiobutton">The radio button.</param>
        [Then(Locale.ThenTheRadioButtonShouldBeReadOnly)]
        public void ThenTheRadioButtonShouldBeReadOnly(string radiobutton)
        {
            Strategy.ThenTheRadioButtonShouldBeReadOnly(radiobutton);
        }
    }
}
