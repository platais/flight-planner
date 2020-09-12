using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Planner.Attributes;
using Flight_Planner.Models;

namespace Flight_Planner.Controllers
{
    //[Route("admin-api")]
    [BasicAuthentication]
    public class AdminController : ApiController
    {
        // GET: api/Admin
        //[HttpGet] //nekas neliecina,ka tas ir get, tapec liekam atributu kvadratiekavaas
        [HttpGet, Route("admin-api/flights/{id}")]
        public HttpResponseMessage Flights(HttpRequestMessage message, int id)

        {
            var flight = FlightStorage.FlightDb.FirstOrDefault(x => x.Id == id);
            if (flight == null)
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }
            return message.CreateResponse(HttpStatusCode.OK, flight);           
        }

        // PUT: api/Admin/5
        [HttpPut, Route("admin-api/flights/{request}")]
        public void Put(object request)
        {

        }

        // DELETE: api/Admin/5
        [HttpDelete, Route("admin-api/flights/{id}")]
        public void Delete(int id)
        {
          
        }
    }
}
