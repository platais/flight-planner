using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Flight_Planner.Core.Models
{
    public class Airport : Entity
    {
        //public int Id { get; set; }
        //[ConcurrencyCheck]
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty("airport")]
        public string AirportCode { get; set; }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (!(o is Airport))
            {
                return false;
            }

            Airport airport = o as Airport;

            return this.Country.ToUpper().Trim() == airport.Country.ToUpper().Trim() &&
                   this.City.ToUpper().Trim() == airport.City.ToUpper().Trim() &&
                   this.AirportCode.ToUpper().Trim() == airport.AirportCode.ToUpper().Trim();
        }

    }
}