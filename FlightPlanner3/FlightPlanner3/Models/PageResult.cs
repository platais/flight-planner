using System.Collections.Generic;

namespace FlightPlanner3.Models
{
    public class PageResult<Flight>
    {
            public int Page { get; set; }
            public int TotalItems { get; set; }
            public List<Flight> Items { get; set; }
    }
}