using System.Collections.Generic;

namespace Flight_Planner.Models
{
    public class PageResult<Flight>
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }
    }
}