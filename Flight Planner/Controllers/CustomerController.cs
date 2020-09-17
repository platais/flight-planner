using Flight_Planner.Models;
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
            Airport[] airpArr = Airport.SearchAirport(search);

            if (airpArr != null)
            {
                return message.CreateResponse(HttpStatusCode.OK, airpArr);
            }

            return message.CreateResponse(HttpStatusCode.NotFound, airpArr);
        }

       [HttpPost, Route("customer-api/flights/search")]
        public HttpResponseMessage SearchFlights(HttpRequestMessage message, object req)
        {
            
            return message.CreateResponse(HttpStatusCode.NotImplemented);
        }

    }
}
