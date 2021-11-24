using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace SOA.WebAPI.Unity
{
    public class UnityDependencyResolver: IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public void Dispose()
        {
            _unityContainer.Dispose();
        }
        /// <summary>
        /// 获取单个服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException  )
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException )
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope() //每次请求
        {
            var child = _unityContainer.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }
    }
}