using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Planner.Attributes;
using Flight_Planner.Models;
using System.Threading.Tasks;

namespace Flight_Planner.Controllers
{
    [BasicAuthentication]
    public class AdminController : ApiController
    {
        //[HttpGet] //nekas neliecina,ka tas ir get, tapec liekam atributu kvadratiekavaas
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

            //flight.Id = FlightStorage.GetId();
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
            //return message.CreateResponse(HttpStatusCode.Created, 
             //   new Flight(flight.From, flight.To, flight.Carrier, flight.DepartureTime, flight.ArrivalTime));

        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public HttpResponseMessage DeleteFlight(HttpRequestMessage message, int id)
        {
            //int index = FlightStorage.GetFlightStorageIndexById(id);
            //ja neiziet, ti nav id 
            if (FlightStorage.GetFlightFromStorageById(id)==null)
            {
               return message.CreateResponse(HttpStatusCode.OK);
            }

            //prieksh datubazes, bet sie nedzesis ara vienu un to pašu, bet vajadzetu..
            FlightStorage.RemoveFlightByDbId(id);
            //FlightStorage.RemoveFlightByStorageIndex(index);
            return message.CreateResponse(HttpStatusCode.OK);
            
        }
    }
}
