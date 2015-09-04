using OpenQA.Selenium;
using SpecFlowHelper.Steps;

namespace SpecFlowHelper.Containers
{
    public abstract class ContainerBase
    {
        protected ContainerBase(StepsBase step, By by)
        {
            By = by;
        }

        public By By { get; private set; }

        public virtual ContainerBase MoveTo(int attempts = 10)
        {
            StepHelper.MoveToElement(By, attempts);

            return this;
        }

        public virtual ContainerBase Click(int attempts = 10)
        {
            StepHelper.Click(By, attempts);

            return this;
        }

        public virtual bool IsVisible(int attempts = 10)
        {
            var result = false;

            StepHelper.Attempt(() =>
            {
                var element = StepHelper.Driver.FindElement(By);
                result = element.Displayed;

                return result;
            }, attempts);

            return result;
        }
    }
}
