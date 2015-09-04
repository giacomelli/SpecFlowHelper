using HelperSharp;
using OpenQA.Selenium;
using SpecFlowHelper.Containers;
using SpecFlowHelper.Steps;

namespace SpecFlowHelper.Steps
{
    public static class AngularJsExtensions
    {
        public static By ByNgModel(this StepsBase step, string ngModel)
        {
            var by = By.XPath("//*[@ng-model='{0}']".With(ngModel));

            return by;
        }

        public static By ByNgClick(this StepsBase step, string ngModel)
        {
            var xpath = "//*[@ng-click=\"{0}\"]".With(ngModel);
            StepHelper.Log("ByNgClick: {0}", xpath);
            var by = By.XPath(xpath);

            return by;
        }

        public static InputContainer Input(this StepsBase step, string ngModel)
        {
            var by = By.XPath("//input[@ng-model='{0}']|//textarea[@ng-model='{0}']".With(ngModel));

            return new InputContainer(step, by);
        }

        public static InputContainer Input(this StepsBase step, By by)
        {
            return new InputContainer(step, by);
        }

        public static ToastContainer Toast(this StepsBase step)
        {
            var by = By.XPath("//div[@ng-class='config.title']");

            return new ToastContainer(step, by);
        }

        public static AnchorContainer Anchor(this StepsBase step, string label)
        {
            var by = By.XPath("//a[contains(., '{0}')]".With(label));

            return new AnchorContainer(step, by);
        }

        public static AnchorContainer Anchor(this StepsBase step, By by)
        {
            return new AnchorContainer(step, by);
        }
    }
}
