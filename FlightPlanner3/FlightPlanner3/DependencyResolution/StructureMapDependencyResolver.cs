

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using StructureMap;

namespace FlightPlanner3.DependencyResolution
{
    public class StructureMapDependencyResolver : StructureMapApiScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container) : base(container)
        {
            _container = container ??
                throw new ArgumentException(nameof(container));
        }

        private readonly IContainer _container;
        public IDependencyScope BeginScope()
        {
            var childContainer = _container.GetNestedContainer();
            return new StructureMapApiScope(childContainer); //StructureMapDependencyResolver(childContainer); 
        }
    }
}