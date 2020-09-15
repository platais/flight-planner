using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class Flight
    {

        public int Id {get; set;}
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Flight))
            {
                return false;
            }

            Flight flight = obj as Flight;

            return flight.From.Equals(this.From) &&
                flight.To.Equals(this.To) &&
                flight.Carrier == this.Carrier &&
                flight.DepartureTime == this.DepartureTime &&
                flight.ArrivalTime == this.ArrivalTime;
        }
    }

}