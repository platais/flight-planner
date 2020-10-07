using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Attributes;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using FlightPlanner3.Models;

namespace FlightPlanner3.Controllers
{
    [BasicAuthentication]
    [Route("admin-api")]
    public class AdminController : BasicApiController
    {
        public AdminController(IFlightService flightService, 
            IMapper mapper) : base(flightService, mapper)
        {
        }

        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlight(int id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null) 
            { 
                return NotFound();
            }
            return Ok(_mapper.Map(flight, new FlightResponse()));
        }

        [HttpGet, Route("admin-api/get/flights")]
        public async Task<IHttpActionResult> GetFlights()
        {
           var flights = await _flightService.GetFlights();

           return Ok(flights
                .Select(f => _mapper.Map<FlightResponse>(f)).ToList());
        }

        [HttpPut, Route("admin-api/flights/")]
        public async Task<IHttpActionResult> PutFlight(Flight flight)
        {
            if (Flight.NotValidFlight(flight) || Flight.IsSameAirport(flight) || Flight.NotValidDate(flight))
            {
                return BadRequest();
            }
            if (await _flightService.FlightExists(flight))
            {
                return Conflict();
            }
            await _flightService.AddFlight(flight);

            return Created("", _mapper.Map(flight, new FlightResponse()));
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public async Task<HttpResponseMessage> DeleteFlight(HttpRequestMessage message, int id)
        {
            if (await _flightService.GetById(id) == null)
            {
                return message.CreateResponse(HttpStatusCode.OK);
            }

            await _flightService.DeleteFlightById(id);
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
