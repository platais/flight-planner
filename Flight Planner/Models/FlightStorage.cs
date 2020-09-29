using System;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        //should be static as controller clears on update
        public static SynchronizedCollection<Flight> FlightDb = new SynchronizedCollection<Flight>();
        private static object _listLock = new object();
        private static int _id = 0;

        public static int GetId()
        {
            object IdLock = new object();
            lock (IdLock)
            {
                return _id++;
            }
        }

        public static void ClearFlightDb()
        {
            FlightDb.Clear();
        }

        public static SynchronizedCollection<Flight> GetFlightDB()
        { 
            return FlightDb;
        }

        public static Flight GetFlightFromStorageById(int id)
        {
            lock (_listLock)
            {
                return GetFlightDB().ToList().FirstOrDefault(x => x.Id == id);
            }
        }

        public static int GetFlightStorageIndexById(int id) 
        {
            lock (_listLock)
            {
                return GetFlightDB().IndexOf(GetFlightFromStorageById(id));
            }
        }
        public static void AddFlight(Flight flight) 
        {
            lock (_listLock)
            {
                GetFlightDB().Add(flight);
            }
        }
        public static void RemoveFlightByStorageIndex(int idx)
        {
            lock (_listLock)
            {
                GetFlightDB().RemoveAt(idx);
            }
        }
        public static bool IsFlightAlreadyInStorage(Flight flight)
        {
            lock (_listLock)
            {
                return GetFlightDB().ToList().Any(f => f.Equals(flight));
            }
        }

        public static List<Flight> GetFlightMatchingRequest(FlightRequest fReq) 
        {
            lock (_listLock)
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
}