using HelperSharp;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default textbox steps strategy.
    /// </summary>
    public class DefaultTextboxStepsStrategy : StepsStrategyBase<TextboxSteps>, ITextboxStepsStrategy
    {
        public virtual void ThenTheFieldShouldHaveTheValue(string field, string value)
        {
            var by = GetBy(field);

            AssertHelper.Attempt(() =>
            {
                var element = this.CurrentSteps.Driver.FindElement(by);
                var inputValue = element.GetAttribute("value");

                return value == inputValue;
            });
        }

        public virtual void WhenTypeEnterOnTheElement(string field)
        {
            StepHelper.PressEnter(this.CurrentSteps.ByNgModel(field));
        }

        public virtual void WhenTypeEnterOnTheField(string field)
        {
            this.CurrentSteps.Input(field).PressEnter();
        }

        public virtual void WhenTypeOnTheField(string value, string field)
        {
            var by = GetBy(field);
            StepHelper.EnterValue(by, value);
        }

        By GetBy(string field) => By.XPath("//input[@id='{0}']|//input[@name='{0}']|//textarea[@id='{0}']|//textarea[@name='{0}']|//input[@ng-model='{0}']|//textarea[@ng-model='{0}']|//input[@formcontrolname='{0}']|//textarea[@formcontrolname='{0}']|//input[@data-path='{0}']|//textarea[@data-path='{0}']".With(field));        
    }
}