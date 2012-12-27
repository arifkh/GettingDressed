// Type: ServiceStack.WebHost.Endpoints.Support.HttpListenerBase
// Assembly: ServiceStack, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\packages\ServiceStack.3.9.32\lib\net35\ServiceStack.dll

using Funq;
using ServiceStack.Html;
using ServiceStack.ServiceHost;
using ServiceStack.VirtualPath;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace ServiceStack.WebHost.Endpoints.Support
{
    public abstract class HttpListenerBase : IDisposable, IAppHost, IResolver
    {
        protected bool IsStarted;
        protected HttpListener Listener;
        protected HttpListenerBase();
        protected HttpListenerBase(string serviceName, params Assembly[] assembliesWithServices);
        public static HttpListenerBase Instance { get; protected set; }
        public Container Container { get; }
        protected IServiceController ServiceController { get; }

        #region IAppHost Members

        public void RegisterAs<T, TAs>() where T : TAs;
        public virtual void Release(object instance);
        public virtual void OnEndRequest();
        public void Register<T>(T instance);
        public T TryResolve<T>();
        public virtual IServiceRunner<TRequest> CreateServiceRunner<TRequest>(ActionContext actionContext);
        public virtual void LoadPlugin(params IPlugin[] plugins);
        public void RegisterService(Type serviceType, params string[] atRestPaths);
        public IServiceRoutes Routes { get; }
        public Dictionary<Type, Func<IHttpRequest, object>> RequestBinders { get; }
        public IContentTypeFilter ContentTypeFilters { get; }
        public List<Action<IHttpRequest, IHttpResponse>> PreRequestFilters { get; }
        public List<Action<IHttpRequest, IHttpResponse, object>> RequestFilters { get; }
        public List<Action<IHttpRequest, IHttpResponse, object>> ResponseFilters { get; }
        public List<IViewEngine> ViewEngines { get; }
        public HandleUncaughtExceptionDelegate ExceptionHandler { get; set; }
        public HandleServiceExceptionDelegate ServiceExceptionHandler { get; set; }
        public List<HttpHandlerResolverDelegate> CatchAllHandlers { get; }
        public EndpointHostConfig Config { get; }
        public List<IPlugin> Plugins { get; }
        public IVirtualPathProvider VirtualPathProvider { get; set; }

        #endregion

        #region IDisposable Members

        public void Dispose();

        #endregion

        protected virtual ServiceManager CreateServiceManager(params Assembly[] assembliesWithServices);
        public void Init();
        public abstract void Configure(Container container);
        public virtual void Start(string urlBase);
        protected void RaiseReceiveWebRequest(HttpListenerContext context);
        public virtual void Stop();
        protected abstract void ProcessRequest(HttpListenerContext context);
        protected void SetConfig(EndpointHostConfig config);
        protected virtual void Dispose(bool disposing);
        public event DelReceiveWebRequest ReceiveWebRequest;
    }
}
