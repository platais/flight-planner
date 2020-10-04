using Flight_Planner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<ServiceResult> AddFlight(Flight flight);
        Task<bool> FlightExists(Flight flight);
        Task<ServiceResult> DeleteFlightById(int id);
        Task DeleteFlight();
    }
}
