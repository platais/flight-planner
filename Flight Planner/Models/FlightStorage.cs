using System.Collections.Generic;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        //ta ka kontrolieri nodzes updeitojot, jabut te static
        public static SynchronizedCollection<Flight> FlightDb = new SynchronizedCollection<Flight>();
        private static int _id = 0;

        public static int GetId()
        {
            return _id++;
        }
    }
}