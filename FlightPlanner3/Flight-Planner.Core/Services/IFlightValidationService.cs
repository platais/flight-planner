using Flight_Planner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    interface IFlightValidationService
    {
        bool NotValidFlight(Flight flight);
        bool IsSameAirport(Flight flight);
        bool NotValidDate(Flight flight);
    }
}
