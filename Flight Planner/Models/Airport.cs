using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class Airport
    {

        private string country;
        private string city;
        private string airport;

        public string Country { get; set; }
        public string City { get; set; }
        public string AirportCode { get; set; }
        public Airport(string Country, string City, string AirportCode)
        {
            country = Country;
            city = City;
            airport = AirportCode;

        }

    }
}