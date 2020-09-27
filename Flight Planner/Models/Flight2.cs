using System;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace Flight_Planner.Models
{
    public class Flight2
    {
        public int Id { get; set; }
        public Airport2 From { get; set; }
        public Airport2 To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public Flight2(Flight f)
        {
            Id = f.Id;
            From = new Airport2(f.From);
            To = new Airport2(f.To);
            Carrier = f.Carrier;
            DepartureTime = f.DepartureTime;
            ArrivalTime = f.ArrivalTime;
        }
    }
}