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
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context) 
        {
        }


        public async Task<ServiceResult> AddFlight(Flight flight)
        {
            //kkadu parbaudi vajadzetu?
            return Create(flight);
        }

        public Task DeleteFlight()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> DeleteFlightById(int id)
        {
            var flight = await GetById(id);
            return Delete(flight);
        }

        public Task<bool> FlightExists(Flight flight)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Query().ToListAsync();
        }
    }
}
