using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        static object IdLock = new object();
        private static int _id = 0;
        public static int GetId()
        {
            //object IdLock = new object();
            //lock (IdLock)
            //{
                return _id++;
            //}
        }

        public static void ClearFlightDb()
        {
                using (var context = new FlightPlannerContext())
                {
                    context.Flights.RemoveRange(context.Flights);
                    context.Airports.RemoveRange(context.Airports);
                    context.SaveChanges();
                }
        }

        public static Flight GetFlightFromStorageById(int id)
        {
            lock (IdLock)
            {//
                using (var context = new FlightPlannerContext())
                {
                    var flight = context.Flights
                        .Include(f => f.To)
                        .Include(f => f.From).ToList()
                        .SingleOrDefault(f => f.Id == id);
                    return flight;
                }
            }//
        }

        public static void AddFlight(Flight flight) 
        {
            lock (IdLock)
            {
                using (var context = new FlightPlannerContext())
                {

                    context.Flights.Add(flight);
                    context.SaveChanges();
                
                }
            }
        }

        public static bool RemoveFlightByDbId(int id)
        {
            lock (IdLock)
            {//
                using (var context = new FlightPlannerContext())
                {

                    if (context.Flights != null)
                    {
                        var flight = context.Flights
                                .Include(f => f.To)
                                .Include(f => f.From)
                                .SingleOrDefault(f => f.Id == id);

                        context.Airports.Remove(flight.To);
                        context.Airports.Remove(flight.From);

                        context.Flights.Remove(flight);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
               
                }
            }//
        }

        public static bool IsFlightAlreadyInStorage(Flight flight)
        {
            lock (IdLock)
            {//
                using (var context = new FlightPlannerContext())
                {
                    if (context.Flights != null)
                    {
                        var fl = context.Flights
                                .Include(f => f.To)
                                .Include(f => f.From).ToList()
                                .Any(f => f.Equals(flight));
                        return fl;
                    }
                    return false;
                }
            }//
        }

        public static List<Flight> GetFlightMatchingRequest(FlightRequest fReq)
        {
            lock (IdLock)
            {//
                using (var context = new FlightPlannerContext())
                {
                    if (context.Flights != null)
                    {
                        var fl = context.Flights
                            .Include(f => f.To)
                            .Include(f => f.From).ToList()
                            .Where(f =>
                            f.From.AirportCode == fReq.From &&
                            f.To.AirportCode == fReq.To &&
                            DateTime.Parse(f.DepartureTime)
                            .ToString("yyyy-MM-dd") ==
                            fReq.DepartureDate)
                            .ToList();
                        return fl;
                    }
                    return null;
                }
            }//
        }
    }
}