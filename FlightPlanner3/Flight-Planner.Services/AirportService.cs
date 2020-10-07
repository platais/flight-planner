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

        public Task<bool> AirportExists(Airport airport)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAirports()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Airport>> GetAirports()
        {
            return await Query().ToListAsync();
        }
        public async Task<IEnumerable<Airport>> SearchAirports(string airportStr)
        {
            string airportStrNormal = airportStr.Trim().ToUpper();
            //HashSet<AirportResponse> strHset = new HashSet<AirportResponse>();
            var li = await Query().ToListAsync();
            var enumAirp = li.Where(f => f.Country.ToUpper().Contains(airportStrNormal) ||
                                    f.City.ToUpper().Contains(airportStrNormal) ||
                                    f.AirportCode.ToUpper().Contains(airportStrNormal));
            
            return enumAirp;
        }
    }
}
