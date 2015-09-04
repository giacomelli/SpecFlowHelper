using OpenQA.Selenium;
using SpecFlowHelper.Steps;

namespace SpecFlowHelper.Containers
{
    public class ToastContainer : ContainerBase
    {
        public ToastContainer(StepsBase step, By by)
            : base(step, by)
        {
        }

        public string Message
        {
            get
            {
                return StepHelper.GetText(By);
            }
        }

        public override ContainerBase Click(int attempts = 10)
        {
            MoveTo(attempts);
            return base.Click(attempts);
        }
    }
}
