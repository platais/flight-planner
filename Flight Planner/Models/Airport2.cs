﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Data.Entity;

namespace Flight_Planner.Models
{
    public class Airport2
    {
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty("airport")]
        public string AirportCode { get; set; }

        public Airport2(Airport a)
        {
            Country = a.Country;
            City = a.City;
            AirportCode = a.AirportCode;
        }
    }
}