using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Services;
using FlightPlanner3.Controllers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FlightPlanner3.Models
{
    public class FlightSearchRequest : BasicApiController
    {
        public FlightSearchRequest(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
        }
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }


        public static bool NotValidFlightRequest(FlightSearchRequest flight)
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

        public static bool IsRequestedFlightPresentInStorage(IEnumerable<Flight> flights, FlightSearchRequest fReq)
        {
            //var flights = await _flightService.GetFlights();
                if (flights.ToList() != null)
                {
                    var fl = flights.ToList()
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

        public static List<Flight> GetFlightMatchingRequest(IEnumerable<Flight> flights, FlightSearchRequest fReq)
        {

                //var fl = await _flightService.GetFlights();
                return flights.Where(f =>
                    f.From.AirportCode == fReq.From &&
                    f.To.AirportCode == fReq.To &&
                    DateTime.Parse(f.DepartureTime)
                    .ToString("yyyy-MM-dd") ==
                    fReq.DepartureDate).ToList();

        }

        public static PageResult<Flight> ReturnPageResults(IEnumerable<Flight> flights, FlightSearchRequest fReq)
        {
            PageResult<Flight> ResList = new PageResult<Flight>();
            //var fl = await _flightService.GetFlights();
            var resultMatched = GetFlightMatchingRequest(flights, fReq).DistinctBy(d => d.DepartureTime).ToList();
            
            ResList.Items = resultMatched;
            ResList.TotalItems = resultMatched.Count;
            ResList.Page = resultMatched.Any() ? 1 : 0;

            return ResList;
        }


    }
}