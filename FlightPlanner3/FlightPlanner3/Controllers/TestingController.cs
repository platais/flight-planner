using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using FlightPlanner3.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    public class TestingController : BasicApiController
    {
        public TestingController(IFlightService flightService, IMapper mapper) 
            : base(flightService, mapper)
        {
        }

        [HttpPost, Route("testing-api/clear")]
        public async Task<IHttpActionResult> ClearFlights(HttpRequestMessage message)
        {
            await _flightService.DeleteFlights();
            return Ok();
        }
    }
}
