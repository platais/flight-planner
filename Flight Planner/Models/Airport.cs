using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Flight_Planner.Models
{
    public class Airport
    {
        public int Id { get; set; }
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

        public static Airport2[] SearchAirport(string airportStr)
        {
            string airportStrNormal = airportStr.Trim().ToUpper();
            HashSet<Airport2> strHset = new HashSet<Airport2>();
            using (var context = new FlightPlannerContext())
            {
                var q = context.Airports.ToList()
                    .Where(f => f.Country.ToUpper().Contains(airportStrNormal) ||
                    f.City.ToUpper().Contains(airportStrNormal) ||
                    f.AirportCode.ToUpper().Contains(airportStrNormal));

                foreach (Airport a in q) 
                {
                    strHset.Add(new Airport2(a));
                }
            }
            return strHset.ToArray();
        }
    }
}