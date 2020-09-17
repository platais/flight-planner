using Flight_Planner.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    public class TestingController : ApiController
    {
        // POST: api/Testing
        [HttpPost, Route("testing-api/clear")]
        public HttpResponseMessage ClearFlights(HttpRequestMessage message)
        {
            FlightStorage.FlightDb.Clear();
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
