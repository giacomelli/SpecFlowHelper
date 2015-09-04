using System;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowHelper.Configuration;
using SpecFlowHelper.Integrations.Browsers;

namespace SpecFlowHelper.Steps.Strategies.AngularJS
{
    public class AngularJSComboboxStepsStrategy : IComboboxStepsStrategy
    {
        private static Func<ComboboxSteps, string, By> WithSearchFinder = (step, field) => By.XPath("//div[@ng-model='{0}']//input|//div[@id='s2id_{0}']//input".With(field));
        public ComboboxSteps CurrentSteps { get; set; }
        
        public virtual void WhenTypeInTheComboboxWithSearch(string value, string field)
        {
            var by = WithSearchFinder(CurrentSteps, field);
            var input = CurrentSteps.Input(by);

            if (AppConfig.BrowserKind == BrowserKind.IE)
            {
                value += "#" + Keys.Backspace;
            }

            input.Write(value);
        }

        public virtual void WhenTypeEnterInTheComboboxWithSearch(string field)
        {
            var by = WithSearchFinder(CurrentSteps, field);

            CurrentSteps.Input(by).PressEnter();
        }

        public virtual void ThenTheComboboxWithSearchShouldHaveTextsSelected(string field, string texts)
        {
            var by = By.XPath("//div[@ng-model='{0}']//span[contains(@class, 'ng-binding')]".With(field));
            var textsSplit = texts.Split(';');
            StepHelper.WaitElementsArePresent(by, textsSplit.Length);
            var elements = CurrentSteps.Driver.FindElements(by);

            Assert.AreEqual(textsSplit.Length, elements.Count);

            for (int i = 0; i < textsSplit.Length; i++)
            {
                Assert.AreEqual(textsSplit[i], elements[i].Text);
            }
        }

        public virtual void WhenRemoveTheItemFromComboboxWithSearch(string item, string field)
        {
            var by = By.XPath("//div[@ng-model='{0}']//span[text()='{1}']/parent::span/preceding-sibling::span".With(field, item));

            StepHelper.Click(by);
        }

        public virtual void ThenTheComboboxShouldHaveTextSelected(string field, string text)
        {
            var by = By.XPath("//select[@selected-id='{0}']/option[@selected='selected']".With(field));

            AssertHelper.AssertTextAreEqual(text, by);
        }

        public virtual void WhenSelectInTheCombobox(string text, string field)
        {
            var by = By.XPath("//select[@ng-model='{0}']".With(field));

            StepHelper.SelectDropdownItem(by, text);
        }
    }
}
