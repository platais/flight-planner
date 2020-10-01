using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Flight_Planner.Attributes;


namespace FlightPlanner3.Controllers
{
    [BasicAuthentication]
    [Route("admin-api")]
    public class AdminController : BasicApiController
    { 
        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlight(int id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null)
                return NotFound();
            return Ok(flight);
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
