using JobSharp;
using Skahal.Infrastructure.Logging.Log4net;
using Topshelf;

namespace SpecFlowHelper.SampleWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsService.Install(
            new Log4netLogStrategy("JobSharpLog"),
            c =>
            {
                c.RunAsLocalSystem();

                c.SetDescription("SpecFlowHelper sample WindowsService.");
                c.SetDisplayName("SpecFlowHelper.SampleWindowsService");
                c.SetServiceName("SpecFlowHelper.SampleWindowsService");
                c.StartAutomatically();
                c.EnableShutdown();
            });
        }
    }
}
