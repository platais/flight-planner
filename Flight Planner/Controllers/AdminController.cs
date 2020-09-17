using System.Linq;
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
        //[HttpGet] //nekas neliecina,ka tas ir get, tapec liekam atributu kvadratiekavaas
        [HttpGet, Route("admin-api/flights/{id}")]
        public HttpResponseMessage GetFlight(HttpRequestMessage message, int id)
        {
            var flight = FlightStorage.FlightDb.FirstOrDefault(x => x.Id == id);
            if (flight == null || flight.Id == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }
            return message.CreateResponse(HttpStatusCode.OK, flight);
        }

        // PUT: api/Admin/5
        [HttpPut, Route("admin-api/flights/")]
        public HttpResponseMessage Put(HttpRequestMessage message, Flight flight)
        {
            if (Flight.NotValidFlight(flight) || Flight.IsSameAirport(flight) || Flight.NotValidDate(flight))
            {
                return message.CreateResponse(HttpStatusCode.BadRequest);
            }
            else if (FlightStorage.FlightDb.ToList().Any(f => f.Equals(flight)))
            //else if (FlightStorage.FlightDb.ToList().Any(f => f.Equals(flight)))
            {
                return message.CreateResponse(HttpStatusCode.Conflict);
            }
            
            flight.Id = FlightStorage.GetId();
            FlightStorage.FlightDb.Add(flight);
            return message.CreateResponse(HttpStatusCode.Created, flight);
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public HttpResponseMessage DeleteFlight(HttpRequestMessage message, int id)
        {
            int index = FlightStorage.FlightDb.FindIndex(el => el.Id == id);
            if (index < 0)
            {
                return message.CreateResponse(HttpStatusCode.OK);
            }

            FlightStorage.FlightDb.RemoveAt(index);
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
