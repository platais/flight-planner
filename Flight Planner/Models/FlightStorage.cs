using System.Collections.Generic;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        private static int _id=0;
        //ta ka kontrolieri nodzes updeitojot, jabut te static
        public static List<Flight> FlightDb = new List<Flight>();
       
        //public static SynchronizedCollection<Flight> FlightDb = new SynchronizedCollection<Flight>();
        //public static ConcurrentBag<Flight> FlightDb = new ConcurrentBag<Flight>();
        public static int GetId()
        {
            return _id++;
        }
    }
}