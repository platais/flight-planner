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

        //šo laikam baigi tomer nevajadzes
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is FlightRequest))
            {
                return false;
            }

            FlightRequest flReq = obj as FlightRequest;

            return flReq.From.ToUpper().Trim().Equals(this.From) &&
                flReq.To.ToUpper().Trim().Equals(this.To) &&
                flReq.DepartureDate == this.DepartureDate;

        }

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
            //and pret or
            return String.IsNullOrEmpty(flight.From) &&
                   String.IsNullOrEmpty(flight.To) &&
                   String.IsNullOrEmpty(flight.DepartureDate);
       
        }

        public static bool IsRequestedFlightPresentInStorage(FlightRequest fReq)
        {

            return FlightStorage.GetFlightDB().ToList()
                .Any(f =>
                    f.From.AirportCode == fReq.From &&
                    f.To.AirportCode == fReq.To &&
                    DateTime.Parse(f.DepartureTime)
                    .ToString("yyyy-MM-dd") ==
                    fReq.DepartureDate);
        }

        public static PageResult<Flight> ReturnPageResults(FlightRequest fReq)
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