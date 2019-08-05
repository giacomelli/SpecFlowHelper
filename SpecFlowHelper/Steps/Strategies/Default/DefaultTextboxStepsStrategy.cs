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
            var by = By.XPath("//input[@id='{0}']|//input[@name='{0}']|//textarea[@id='{0}']|//textarea[@name='{0}']|//input[@ng-model='{0}']|//textarea[@ng-model='{0}']".With(field));

            StepHelper.Attempt(() =>
            {
                var element = this.CurrentSteps.Driver.FindElement(by);
                var inputValue = element.GetAttribute("value");

                Assert.AreEqual(value, inputValue, inputValue);

                return true;
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
            var by = By.XPath("//input[@id='{0}']|//input[@name='{0}']|//textarea[@id='{0}']|//textarea[@name='{0}']|//input[@ng-model='{0}']|//textarea[@ng-model='{0}']".With(field));
            StepHelper.EnterValue(by, value);
        }
    }
}