using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowHelper.Configuration
{
    public static class WebProjectConfigExtensions
    {
        public static WebProjectConfig SingleWebApi(this IEnumerable<WebProjectConfig> webProjects)
        {
            var apis = webProjects.Where(p => p.Kind == WebProjectKind.Api).ToArray();

            if (apis.Length == 0)
                throw new InvalidOperationException("There is no web api configured (check the AppConfig.WebProjects)");

            if (apis.Length > 1)
                throw new InvalidOperationException("There is more than one web api configured (check the AppConfig.WebProjects)");

            return apis[0];
        }

        public static WebProjectConfig[] WebApps(this IEnumerable<WebProjectConfig> webProjects)
        {
            return webProjects.Where(p => p.Kind == WebProjectKind.App).ToArray();
        }
    }
}
