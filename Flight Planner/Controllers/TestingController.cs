using Flight_Planner.Attributes;
using Flight_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    public class TestingController : ApiController
    {
        // POST: api/Testing
        [HttpPost, Route("testing-api/clear")]
        public HttpResponseMessage ClearFlight(HttpRequestMessage message)
        {

            if (FlightStorage.FlightDb != null)
            {
                FlightStorage.FlightDb.Clear();
            }
            else 
            {
                return message.CreateResponse(HttpStatusCode.NotFound);
            }

            return message.CreateResponse(HttpStatusCode.OK);
        }
        // GET: api/Testing
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/Testing/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Testing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Testing/5
        public void Delete(int id)
        {
        }
    }
}
