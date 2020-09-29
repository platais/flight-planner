using Flight_Planner.Core.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    public class TestingController : ApiController
    {
        [HttpPost, Route("testing-api/clear")]
        public HttpResponseMessage ClearFlights(HttpRequestMessage message)
        {
            //FlightStorage.ClearFlightDb();
            return message.CreateResponse(HttpStatusCode.OK);
        }
    }
}
