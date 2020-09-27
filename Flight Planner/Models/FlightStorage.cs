using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Flight_Planner.Models
{
    public class FlightStorage
    {
        //should be static as controller clears on update
        //private static object _listLock = new object();
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
            using (var context = new FlightPlannerContext())
            {
                context.Flights.RemoveRange(context.Flights);
                context.Airports.RemoveRange(context.Airports);
                context.SaveChanges();
            }
        }

        public static Flight GetFlightFromStorageById(int id)
        {
            using(var context = new FlightPlannerContext())
            {
                var flight = context.Flights
                    .Include(f => f.To)
                    .Include(f => f.From).ToList()//šitais include nav tas pats kas no linq
                    .SingleOrDefault(f => f.Id == id);
                return flight;
            }
        }

        public static void AddFlight(Flight flight) 
        {
            using (var context = new FlightPlannerContext()) 
            {
                context.Flights.Add(flight);
                    
                //nez vai šo vajag
                //context.Airports.Add(flight.To);
                //context.Airports.Add(flight.From);

                context.SaveChanges();
            }
        }

        public static bool RemoveFlightByDbId(int id)
        {
            using (var context = new FlightPlannerContext())
            {
              
                if (context.Flights != null) {
                    var flight = context.Flights
                            .Include(f => f.To)
                            .Include(f => f.From)//šitais include nav tas pats kas no linq
                            .SingleOrDefault(f => f.Id == id);

                    context.Airports.Remove(flight.To);
                    context.Airports.Remove(flight.From);

                    context.Flights.Remove(flight);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

        }

        public static bool IsFlightAlreadyInStorage(Flight flight)
        {
            using (var context = new FlightPlannerContext())
            {
                if (context.Flights != null)
                {
                    var fl = context.Flights
                            .Include(f => f.To)
                            .Include(f => f.From).ToList()//šitais include nav tas pats kas no linq
                            .Any(f => f.Equals(flight));
                    return fl;
                }
                return false;
            }
            
        }

        public static List<Flight> GetFlightMatchingRequest(FlightRequest fReq)
        {
            //lock (_listLock)
            //{
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
        }

    }
}