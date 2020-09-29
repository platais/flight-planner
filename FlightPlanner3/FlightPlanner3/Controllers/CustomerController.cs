using Flight_Planner.Core.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet, Route("api/airports")]
        public HttpResponseMessage SearchAirport(HttpRequestMessage message, string search)
        {
            return null;
        }

        [HttpGet, Route("api/flights/{id}")]
        public HttpResponseMessage GetFlightById(HttpRequestMessage message, int id)
        {
            return null;
        }

        [HttpPost, Route("api/flights/search")]
        public HttpResponseMessage SearchFlights(HttpRequestMessage message)//,// FlightRequest req)
        {
            return null;
        }
    }
}
