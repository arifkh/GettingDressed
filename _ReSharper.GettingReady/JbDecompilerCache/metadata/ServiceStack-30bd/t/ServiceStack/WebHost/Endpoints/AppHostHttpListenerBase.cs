// Type: ServiceStack.WebHost.Endpoints.AppHostHttpListenerBase
// Assembly: ServiceStack, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\packages\ServiceStack.3.9.32\lib\net35\ServiceStack.dll

using ServiceStack.WebHost.Endpoints.Support;
using System.Net;
using System.Reflection;

namespace ServiceStack.WebHost.Endpoints
{
    public abstract class AppHostHttpListenerBase : HttpListenerBase
    {
        protected AppHostHttpListenerBase();
        protected AppHostHttpListenerBase(string serviceName, params Assembly[] assembliesWithServices);
        protected AppHostHttpListenerBase(string serviceName, string handlerPath, params Assembly[] assembliesWithServices);
        protected override void ProcessRequest(HttpListenerContext context);
    }
}
