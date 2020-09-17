using Flight_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flight_Planner.Controllers
{
    //[Route("customer-api")]

    public class CustomerController : ApiController
    {

        [HttpGet, Route("api/airports")]
        public HttpResponseMessage SearchAirport(HttpRequestMessage message, string search)
        {
            //Airport[] airpArr = new Airport[1];
            Airport[] airpArr = Airport.SearchAirport(search);

            //if (airpArr.FirstOrDefault() != null)
            if (airpArr != null)
            {
                return message.CreateResponse(HttpStatusCode.OK, airpArr);
            }

            return message.CreateResponse(HttpStatusCode.NotFound, airpArr);

        }

        // POST: api/Api
        //[HttpPost, Route("customer-api/flights/search")]
        //public HttpResponseMessage SearchFlights(HttpRequestMessage message)
        //{
        //    //return customerClient.post('/flights/search', req)
        //    return message.CreateResponse(HttpStatusCode.NotImplemented);
        //}

    }
}
