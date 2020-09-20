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
        public async Task<HttpResponseMessage> SearchAirport(HttpRequestMessage message, string search)
        {
            Airport[] airpArr = Airport.SearchAirport(search);

            if (airpArr != null)
            {
                return message.CreateResponse(HttpStatusCode.OK, airpArr);
            }

            return message.CreateResponse(HttpStatusCode.NotFound, airpArr);
        }

        [HttpGet, Route("api/flights/{id}")]
        public async Task<HttpResponseMessage> GetFlightById(HttpRequestMessage message, int id)
        {
            var flight = FlightStorage.FlightDb.FirstOrDefault(x => x.Id == id);
            if (flight == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }
            return message.CreateResponse(HttpStatusCode.OK, flight);
        }

        [HttpPost, Route("api/flights/search")]
        public async Task<HttpResponseMessage> SearchFlights(HttpRequestMessage message, FlightRequest req)
        {
            if (FlightRequest.NotValidFlightRequest(req))
            {
                return message.CreateResponse(HttpStatusCode.BadRequest);
            }

            var pr = FlightRequest.ReturnPageResults(req);
            return message.CreateResponse(HttpStatusCode.OK, pr);
        }
    }
}
