using Newtonsoft.Json;

namespace FlightPlanner3.Models
{
    public class AirportResponse
    {
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty("airport")]
        public string AirportCode { get; set; }

    }
}