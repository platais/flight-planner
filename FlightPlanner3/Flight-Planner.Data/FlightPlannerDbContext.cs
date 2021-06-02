using Flight_Planner.Core.Models;
using Flight_Planner.Data.Migrations;
using System.Data.Entity;

namespace Flight_Planner.Data
{
    public class FlightPlannerDbContext: DbContext, IFlightPlannerDbContext
    {
        public FlightPlannerDbContext() : base("flight-planner3")
        {
            //nB!ZRi!
            Database.SetInitializer<FlightPlannerDbContext>
                (new MigrateDatabaseToLatestVersion<FlightPlannerDbContext,Configuration>());
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
