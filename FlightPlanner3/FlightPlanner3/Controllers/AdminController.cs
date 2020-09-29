using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Planner.Attributes;


namespace FlightPlanner3.Controllers
{
    [BasicAuthentication]
    public class AdminController : ApiController
    {
        [HttpGet, Route("admin-api/flights/{id}")]
        public HttpResponseMessage GetFlight(HttpRequestMessage message, int id)
        {
            return null;
        }

        [HttpPut, Route("admin-api/flights/")]
        public HttpResponseMessage AddFlight(HttpRequestMessage message)
        {
            return null;
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public HttpResponseMessage DeleteFlight(HttpRequestMessage message, int id)
        {
            return null;
        }
    }
}
