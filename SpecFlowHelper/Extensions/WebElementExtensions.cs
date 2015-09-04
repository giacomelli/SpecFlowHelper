using SpecFlowHelper.Containers;

namespace SpecFlowHelper.Steps
{
    /// <summary>
    /// WebElement extension methods.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Writes the specified value.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="value">The value.</param>
        public static void Write(this InputContainer input, string value)
        {
            StepHelper.EnterValue(input.By, value);
        }

        /// <summary>
        /// Press the enter.
        /// </summary>
        /// <param name="input">The input.</param>
        public static void PressEnter(this InputContainer input)
        {
            StepHelper.PressEnter(input.By);
        }

        /// <summary>
        /// Press the tab.
        /// </summary>
        /// <param name="input">The input.</param>
        public static void PressTab(this InputContainer input)
        {
            StepHelper.PressTab(input.By);
        }
    }
}
