using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Planner.Attributes;
using Flight_Planner.Models;

namespace Flight_Planner.Controllers
{
    [BasicAuthentication]
    public class AdminController : ApiController
    {
        [HttpGet, Route("admin-api/flights/{id}")]
        public HttpResponseMessage GetFlight(HttpRequestMessage message, int id)
        {
            var flight = FlightStorage.GetFlightFromStorageById(id);
            if (flight == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }
            return message.CreateResponse(HttpStatusCode.OK, flight);
        }

        [HttpPut, Route("admin-api/flights/")]
        public HttpResponseMessage AddFlight(HttpRequestMessage message, Flight flight)
        {
            if (Flight.NotValidFlight(flight) || Flight.IsSameAirport(flight)  || Flight.NotValidDate(flight))
            {
                return message.CreateResponse(HttpStatusCode.BadRequest);
            }
            if (FlightStorage.IsFlightAlreadyInStorage(flight))
            {
                return message.CreateResponse(HttpStatusCode.Conflict);
            }

            flight.Id = FlightStorage.GetId();
            FlightStorage.AddFlight(flight);

            return message.CreateResponse(HttpStatusCode.Created, new Flight2(flight));
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public HttpResponseMessage DeleteFlight(HttpRequestMessage message, int id)
        {
            if (FlightStorage.GetFlightFromStorageById(id) == null)
            {
               return message.CreateResponse(HttpStatusCode.OK);
            }

            FlightStorage.RemoveFlightByDbId(id);
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
