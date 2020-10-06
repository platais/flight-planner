using Flight_Planner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        Task<IEnumerable<Airport>> SearchAirports(string str);
        Task<IEnumerable<Airport>> GetAirports();
        Task<bool> AirportExists(Airport airport);
        Task DeleteAirports();
    }
}
