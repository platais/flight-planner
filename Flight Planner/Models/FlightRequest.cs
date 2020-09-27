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
            using (var context = new FlightPlannerContext())
            {
                if (context.Flights != null)
                {
                    var fl = context.Flights.ToList()
                    .Any(f =>
                        f.From.AirportCode == fReq.From &&
                        f.To.AirportCode == fReq.To &&
                        DateTime.Parse(f.DepartureTime)
                        .ToString("yyyy-MM-dd") ==
                        fReq.DepartureDate);
                    return fl;
                }
                return false;
            }
        }

        public static PageResult<Flight> ReturnPageResults(FlightRequest fReq)
        {
                PageResult<Flight> ResList = new PageResult<Flight>();

                var resultMatched = FlightStorage.GetFlightMatchingRequest(fReq);

                ResList.Items = resultMatched;
                //uz total items met kluudu
                ResList.TotalItems = resultMatched.Count;
                ResList.Page = resultMatched.Any() ? 1 : 0;

                return ResList;
        }
    }
}