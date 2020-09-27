using Flight_Planner.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet, Route("api/airports")]
        public HttpResponseMessage SearchAirport(HttpRequestMessage message, string search)
        {
            Airport2[] airpArr = Airport.SearchAirport(search);

            if (airpArr == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound, airpArr);
            }

            return message.CreateResponse(HttpStatusCode.OK, airpArr);
        }

        [HttpGet, Route("api/flights/{id}")]
        public HttpResponseMessage GetFlightById(HttpRequestMessage message, int id)
        {

            var flight = FlightStorage.GetFlightFromStorageById(id);

            if (flight == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }

            return message.CreateResponse(HttpStatusCode.OK, new Flight2(flight));
        }

        [HttpPost, Route("api/flights/search")]
        public HttpResponseMessage SearchFlights(HttpRequestMessage message, FlightRequest req)
        {
            if (FlightRequest.NotValidFlightRequest(req) 
                && !FlightRequest.IsRequestedFlightPresentInStorage(req))
            {
                return message.CreateResponse(HttpStatusCode.BadRequest);
            }

            var pr = FlightRequest.ReturnPageResults(req);
            return message.CreateResponse(HttpStatusCode.OK, pr);
        }
    }
}
