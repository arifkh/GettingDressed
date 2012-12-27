// Type: Microsoft.Practices.Unity.UnityContainer
// Assembly: Microsoft.Practices.Unity, Version=2.1.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\dev\Prototypes\GettingReady\packages\Unity.2.1.505.0\lib\NET35\Microsoft.Practices.Unity.dll

using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity
{
    public class UnityContainer : IUnityContainer, IDisposable
    {
        public UnityContainer();

        #region IUnityContainer Members

        public IUnityContainer RegisterType(Type from, Type to, string name, LifetimeManager lifetimeManager, InjectionMember[] injectionMembers);
        public IUnityContainer RegisterInstance(Type t, string name, object instance, LifetimeManager lifetime);
        public object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides);
        public IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides);
        public object BuildUp(Type t, object existing, string name, params ResolverOverride[] resolverOverrides);
        public void Teardown(object o);
        public IUnityContainer AddExtension(UnityContainerExtension extension);
        public object Configure(Type configurationInterface);
        public IUnityContainer RemoveAllExtensions();
        public IUnityContainer CreateChildContainer();
        public void Dispose();
        public IUnityContainer Parent { get; }
        public IEnumerable<ContainerRegistration> Registrations { get; }

        #endregion

        protected virtual void Dispose(bool disposing);
    }
}
