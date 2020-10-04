using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner3.Models
{
    public class FlightSearchRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }
    }
}