using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using FlightPlanner3.Controllers;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using FlightPlanner3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Controllers
{
    public class CustomerController : BasicApiController
    {
        private readonly IAirportService _airportService;
        public CustomerController(IAirportService airportService, IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
            _airportService = airportService;
        }

        [HttpGet, Route("api/airports")]
        public async Task<IHttpActionResult> SearchAirport(string search)
        {
            var airpEnum = await _airportService.SearchAirports(search);
            HashSet<AirportResponse> strHset = new HashSet<AirportResponse>();
            foreach (Airport a in airpEnum)
            {
                strHset.Add(_mapper.Map(a, new AirportResponse()));
            }
            var airpArr = strHset.ToArray();
            if (airpArr == null)
            {
                return Content(HttpStatusCode.NotFound, airpArr);
            }
            return Ok(airpArr);
        }

        [HttpGet, Route("api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlightByIdAsync(int id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null) 
            { 
                return NotFound();
            }
            return Ok(_mapper.Map(flight, new FlightResponse()));
        }

        [HttpPost, Route("api/flights/search")]
        public async Task<IHttpActionResult> SearchFlights(FlightSearchRequest req)
        {
            var fl = await _flightService.GetFlights();
            var pr = FlightSearchRequest.ReturnPageResults(fl, req);

            if (FlightSearchRequest.NotValidFlightRequest(req)
                && !FlightSearchRequest.IsRequestedFlightPresentInStorage(fl,req))
            {
                return Content(HttpStatusCode.BadRequest, pr);
            }

            return Ok(pr);
        }
    }
}
