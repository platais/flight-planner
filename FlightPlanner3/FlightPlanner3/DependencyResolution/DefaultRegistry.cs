// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FlightPlanner3.DependencyResolution {
    using AutoMapper;
    using Flight_Planner.Core.Services;
    using Flight_Planner.Services;
    using Flight_Planner.Data;
    using FlightPlanner3.App_Start;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            //tiksiem vala no usingiem ieks dbcontext, sitais menedzes
            For<IFlightPlannerDbContext>().Use<FlightPlannerDbContext>().Transient();
            For<IDbService>().Use<DbService>();//te kluda
            For(typeof(IEntityService<>)).Use(typeof(EntityService<>));//te ari kluda
            For<IFlightService>().Use<FlightService>();
            For<IAirportService>().Use<AirportService>();
            var mapper = AutoMapperConfig.GetMapper();
            For<IMapper>().Use(mapper).Singleton();
        }

        #endregion
    }
}