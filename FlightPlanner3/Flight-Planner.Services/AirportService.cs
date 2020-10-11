using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;


namespace Flight_Planner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext context) : base(context) 
        {
        }

        public async Task<bool> AirportExists(Airport airport)
        {
            var li = await Query().ToListAsync();
            var res = li.Contains(airport);
            return res;
        }

        public async Task DeleteAirports()
        {
            _ctx.Airports.RemoveRange(_ctx.Airports);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Airport>> GetAirports()
        {
            return await Query().ToListAsync();
        }
        public async Task<IEnumerable<Airport>> SearchAirports(string airportStr)
        {
            string airportStrNormal = airportStr.Trim().ToUpper();
            var li = await Query().ToListAsync();
            var enumAirp = li.Where(f => f.Country.ToUpper().Contains(airportStrNormal) ||
                                    f.City.ToUpper().Contains(airportStrNormal) ||
                                    f.AirportCode.ToUpper().Contains(airportStrNormal));
            return enumAirp;
        }
    }
}
