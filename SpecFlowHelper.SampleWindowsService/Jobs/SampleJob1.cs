using System.Threading;
using JobSharp;

namespace SpecFlowHelper.SampleWindowsService.Jobs
{
    public class SampleJob1 : IJob
    {
        public void Run()
        {
            LogService.Write("Starting SampleJob1");
            Thread.Sleep(1000);
            LogService.Write("SampleJob1 done");
        }
    }
}
