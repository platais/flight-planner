using AutoMapper;
using Flight_Planner.Core.Services;
using System.Web.Http;

namespace FlightPlanner3.Controllers
{
    public class BasicApiController : ApiController
    {
        protected readonly IFlightService _flightService;
        protected readonly IMapper _mapper;

        public BasicApiController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }
    }
}
