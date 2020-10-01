

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using StructureMap;

namespace FlightPlanner3.DependencyResolution
{
    public class StructureMapDependencyResolver : StructureMapApiScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container) : base(container)//
        {
            _container = container ??
                throw new ArgumentException(nameof(container));
        }

        private readonly IContainer _container;

        public object GetService(Type serviceType)
        {
            if (serviceType == null) 
            {
                return null;
            }
            if (serviceType.IsAbstract || serviceType.IsInterface) 
            {
                return _container.TryGetInstance(serviceType);
            }
            return _container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            yield return _container.GetAllInstances(serviceType);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
        public IDependencyScope BeginScope()
        {
            var childContainer = _container.GetNestedContainer();
            return new StructureMapDependencyResolver(childContainer);
        }
    }
}