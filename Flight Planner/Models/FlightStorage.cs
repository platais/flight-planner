using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void ClearFlightDb()
        {
            FlightDb.Clear();
        }

        public static SynchronizedCollection<Flight> GetFlightDB()
        { 
            object ListLock = new object();
            lock (ListLock)
            {
                return FlightDb; //= new SynchronizedCollection<Flight>();
            }
        }

        public static Flight GetFlightFromStorageById(int id)
        {//Collection was modified; enumeration operation may not execute.'
            //ar visu lock
            object ListLock = new object();
            lock (ListLock)
            {
                return GetFlightDB().ToList().FirstOrDefault(x => x.Id == id);
            }
        }

        public static int GetFlightStorageIndexById(int id) 
        {
            return GetFlightDB().IndexOf(GetFlightFromStorageById(id));
        }
        public static void AddFlight(Flight flight) 
        {
            GetFlightDB().Add(flight);
        }
        public static void RemoveFlightByStorageIndex(int idx)
        {
            GetFlightDB().RemoveAt(idx);
        }
        public static bool IsFlightAlreadyInStorage(Flight flight)
        {//Destination array was not long enough. Check destIndex and length, and the array's lower bounds.'
            object ListLock = new object();
            lock (ListLock)
            {
                return GetFlightDB().ToList().Any(f => f.Equals(flight));
            }
        }

        ////šo nevajag, bet testam
        //public static Flight GetFlightFromStorage(Flight flight)
        //{
        //    return GetFlightDB().ToList().FirstOrDefault(f => f.Equals(flight));
        //}

        public static List<Flight> GetFlightMatchingRequest(FlightRequest fReq) 
        {
            return GetFlightDB().ToList().Where(f =>
                    f.From.AirportCode == fReq.From &&
                    f.To.AirportCode == fReq.To &&
                    DateTime.Parse(f.DepartureTime)
                    .ToString("yyyy-MM-dd") ==
                    fReq.DepartureDate)
                    .ToList();
        }
    }
}