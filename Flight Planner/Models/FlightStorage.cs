using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        private static int _id=1;
        //ta ka kontrolieri nodzes updeitojot, jabut te static
        public static List<Flight> FlightDb = new List<Flight>();

        public static int GetId()
        {
            return _id++;
        }

    }
}