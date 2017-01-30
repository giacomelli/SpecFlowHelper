using System;
using HelperSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SpecFlowHelper.Steps.Strategies.Default
{
    /// <summary>
    /// Default toast steps strategy.
    /// </summary>
    public class DefaultToastStepsStrategy : StepsStrategyBase<ToastSteps>, IToastStepsStrategy
    {
        public virtual void ThenShouldShowTheToast(string message)
        {
            StepHelper.Attempt(() =>
            {
                var toastMessage = CurrentSteps.Toast().Message;
                Assert.AreEqual(message, toastMessage, "A mensagem esperada no toast era: {0}, mas foi {1}".With(message, toastMessage));

                return true;
            });
        }
        
        public virtual void ThenCloseTheToast()
        {
            StepHelper.Attempt(() =>
            {
                var toast = CurrentSteps.Toast();

                if (StepHelper.IsElementPresent(toast.By))
                {
                    toast.Click(1);

                    if (StepHelper.IsElementPresent(toast.By))
                    {
                        toast.Click(1);
                    }
                }

                return true;
            });
        }
    }
}