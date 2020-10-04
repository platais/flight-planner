using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner3.Models
{
    public class FlightResponse
    {

        public AirportResponse From { get; set; }
        public AirportResponse To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}