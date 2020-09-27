using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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