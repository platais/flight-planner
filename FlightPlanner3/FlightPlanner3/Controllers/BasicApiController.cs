using AutoMapper;
using Flight_Planner.Core.Services;
using Flight_Planner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightPlanner3.Controllers
{
    public class BasicApiController : ApiController
    {
        //protected readonly IAirportService _airportService;
        protected readonly IFlightService _flightService;
        protected readonly IMapper _mapper;

        public BasicApiController(IFlightService flightService, IMapper mapper)//,IAirportService airportService);
        {
            //_airportService = airportService;
            _flightService = flightService;
            _mapper = mapper;
        }

    }
}
