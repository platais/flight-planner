using System.Data.Entity;

namespace Flight_Planner.Models
{
    public class FlightPlannerContext : DbContext
    {
        public FlightPlannerContext():base("flight-planner")
        {
            Database.SetInitializer<FlightPlannerContext>(null);
                //new CreateDatabaseIfNotExists<FlightPlannerContext>());
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; } 
    }
}