using JobSharp;

namespace SpecFlowHelper.SampleWindowsService.Jobs
{
    public class SampleJob2 : IJob
    {
        public void Run()
        {
            LogService.Write("Starting SampleJob2");
            LogService.Write("SampleJob2 done");
        }
    }
}
