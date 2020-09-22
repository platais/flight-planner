using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Flight_Planner.Models
{
    public class Airport
    {
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
        public static Airport[] SearchAirport(string airportStr) 
        {
            string airportStrNormal = airportStr.Trim().ToUpper();
            HashSet<Airport> strHset = new HashSet<Airport>();

            foreach (Flight a in FlightStorage.GetFlightDB())
            {  
                if (a.From.Country.ToUpper().Contains(airportStrNormal) ||
                        a.From.City.ToUpper().Contains(airportStrNormal) ||
                        a.From.AirportCode.ToUpper().Contains(airportStrNormal))
                {
                    strHset.Add(a.From);               
                }

                if (a.To.Country.ToUpper().Contains(airportStrNormal) ||
                     a.To.City.ToUpper().Contains(airportStrNormal) ||
                     a.To.AirportCode.ToUpper().Contains(airportStrNormal))
                {
                    strHset.Add(a.To);
                } 
            }
            return strHset.ToArray();
        }
    }
}