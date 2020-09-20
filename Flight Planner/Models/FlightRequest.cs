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

           // DateTime.Parse(flReq.DepartureDate)
           //    .Equals(DateTime.Parse(this.DepartureDate)
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
            return String.IsNullOrEmpty(flight.From) &&
                   String.IsNullOrEmpty(flight.To) &&
                   String.IsNullOrEmpty(flight.DepartureDate);
       
        }

        public static PageResult<Flight> ReturnPageResults(FlightRequest fReq)
        {
                PageResult<Flight> ResList = new PageResult<Flight>();

                var resultMatched = FlightStorage.FlightDb
                .Where(f =>
                f.From.AirportCode.Equals(fReq.From) &&
                f.To.AirportCode.Equals(fReq.To) &&
                DateTime.Parse(f.DepartureTime)
                .Equals(DateTime.Parse(fReq.DepartureDate)))
                .ToList();

                ResList.Items = resultMatched;
                ResList.TotalItems = resultMatched.Count;
                ResList.Page = resultMatched.Any() ? 1 : 0;

                return ResList;
        }
    }
}