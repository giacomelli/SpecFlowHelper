using System.Web.Http;

namespace SpecFlowHelper.SampleWebApi.Controllers
{
    public class SampleController : ApiController
    {
        private static int s_value;

        [HttpGet]
        public string Get()
        {
            return "Current sample " + (++s_value);
        }
    }
}
