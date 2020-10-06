using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using FlightPlanner3.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using FlightPlanner3.Models;

namespace Flight_Planner.Controllers
{
    public class CustomerController : BasicApiController
    {
        public CustomerController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {

        }
        [HttpGet, Route("api/airports")]
        public HttpResponseMessage SearchAirport(HttpRequestMessage message, string search)
        {
            //Airport2[] airpArr = Airport.SearchAirport(search);

            //if (airpArr == null)
            //{
            //    return message.CreateResponse(HttpStatusCode.NotFound, airpArr);
            //}

            //return message.CreateResponse(HttpStatusCode.OK, airpArr);
            return null;
        }

        [HttpGet, Route("api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlightByIdAsync(HttpRequestMessage message, int id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null) 
            { 
                return NotFound();
            }
            return Ok(_mapper.Map(flight, new FlightResponse()));
        }

        [HttpPost, Route("api/flights/search")]
        public HttpResponseMessage SearchFlights(HttpRequestMessage message, FlightRequest req)
        {
            //if (FlightRequest.NotValidFlightRequest(req)
            //    && !FlightRequest.IsRequestedFlightPresentInStorage(req))
            //{
            //    return message.CreateResponse(HttpStatusCode.BadRequest);
            //}

            //var pr = FlightRequest.ReturnPageResults(req);
            //return message.CreateResponse(HttpStatusCode.OK, pr);
            return null;
        }
    }
}
