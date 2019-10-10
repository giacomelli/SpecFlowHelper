using System.Net;

namespace SpecFlowHelper.Configuration
{
    public enum WebProjectKind
    {
        Api,
        App
    }

    public class WebProjectConfig
    {
        public WebProjectConfig(WebProjectKind kind, string folderName, int port = 80)
        {
            Kind = kind;
            FolderName = folderName;
            Port = port;

            BaseUrl = $"http://localhost:{port}";
        }

        public WebProjectConfig(WebProjectKind kind)
        {
            Kind = kind;
        }

        public WebProjectKind Kind { get; private set; }

        public string FolderName { get; private set; }
        public int Port { get; private set; }
        public string BaseUrl { get; set; }

        public HttpStatusCode? ExpectedStatusCode { get; set; } = HttpStatusCode.OK;        
    }
}
