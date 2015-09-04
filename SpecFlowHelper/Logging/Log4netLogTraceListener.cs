using System;
using SpecFlowHelper.Steps;
using TechTalk.SpecFlow.Tracing;

namespace SpecFlowHelper.Logging
{
    public class Log4netLogTraceListener : ITraceListener
    {
        private bool m_testOutputEnabled = true;

        public void WriteTestOutput(string message)
        {
            if (message.StartsWith("#####"))
            {
                m_testOutputEnabled = true;
            }

            if (m_testOutputEnabled)
            {
                StepHelper.Log(message);
            }
        }

        public void WriteToolOutput(string message)
        {
            if (message.StartsWith("binding error:"))
            {
                throw new InvalidOperationException(message);
            }

            m_testOutputEnabled = !message.StartsWith("skipped because of previous errors");

            if (m_testOutputEnabled && !message.StartsWith("done: "))
            {
                StepHelper.Log(message);
            }
        }
    }
}
