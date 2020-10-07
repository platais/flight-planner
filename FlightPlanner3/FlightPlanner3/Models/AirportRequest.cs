using Flight_Planner.Core.Models;
using Newtonsoft.Json;

namespace FlightPlanner3.Models
{
    public class AirportRequest : Entity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty("airport")]
        public string AirportCode { get; set; }
    }
}