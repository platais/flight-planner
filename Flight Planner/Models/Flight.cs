using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class Flight
    {
        private int id;
        private Airport from;
        private Airport to;
        private string carrier;
        //private DateTime departureTime;
        private string departureTime;
        private string arrivalTime;


        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

    }
}