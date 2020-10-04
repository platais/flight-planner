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
        public AdminController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {

        }
        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlight(int id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null)
                return NotFound();
           
            return Ok(
                _mapper.Map(flight, new FlightResponse())
                );
        }

        [HttpGet, Route("admin-api/get/flights")]
        public async Task<IHttpActionResult> GetFlights()
        {//metode var but tikai await, ja task
            //NEKAD Task<void> , ja neko, tad bez void , arī async void nē, reizem izies, reizem neizies
           var flights = await _flightService.GetFlights();
            return Ok(
                flights
                .Select(f => _mapper.Map<FlightResponse>(f)).ToList());


        }

        [HttpPut, Route("admin-api/flights/")]
        public async Task<IHttpActionResult> PutFlight(FlightRequest flight)
        {
            var fl = await _flightService.AddFlight(_mapper.Map<Flight>(flight));
            //kadu vel string
            return Created("ok", new FlightResponse());
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public async Task<HttpResponseMessage> DeleteFlight(HttpRequestMessage message, int id)
        {
            await _flightService.DeleteFlightById(id);
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
