using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class FlightRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }

        public static bool NotValidFlightRequest(FlightRequest flight)
        {
            if (flight == null)
            {
                return true;
            }
            if (flight.From == flight.To)
            {
                return true;
            }
            
            return String.IsNullOrEmpty(flight.From) &&
                   String.IsNullOrEmpty(flight.To) &&
                   String.IsNullOrEmpty(flight.DepartureDate);
       
        }

        public static bool IsRequestedFlightPresentInStorage(FlightRequest fReq)
        {
            object ListLock = new object();
            lock (ListLock)
            {
                return FlightStorage.GetFlightDB().ToList()
                .Any(f =>
                    f.From.AirportCode == fReq.From &&
                    f.To.AirportCode == fReq.To &&
                    DateTime.Parse(f.DepartureTime)
                    .ToString("yyyy-MM-dd") ==
                    fReq.DepartureDate);
            }
        }

        public static PageResult<Flight> ReturnPageResults(FlightRequest fReq)
        {
            object ListLock = new object();
            lock (ListLock)
            {
                PageResult<Flight> ResList = new PageResult<Flight>();

                var resultMatched = FlightStorage.GetFlightMatchingRequest(fReq);

                ResList.Items = resultMatched;
                //ir vai nu 2,3 vai 0, vai retos gad iziet
                ResList.TotalItems = resultMatched.Count;
                ResList.Page = resultMatched.Any() ? 1 : 0;

                return ResList;
            }
        }
    }
}