// Type: ServiceStack.ServiceHost.RouteAttribute
// Assembly: ServiceStack.Interfaces, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\packages\ServiceStack.Common.3.9.32\lib\net35\ServiceStack.Interfaces.dll

using System;

namespace ServiceStack.ServiceHost
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string path);
        public RouteAttribute(string path, string verbs);
        public string Path { get; set; }
        public string Summary { get; set; }
        public string Notes { get; set; }
        public string Verbs { get; set; }
    }
}
