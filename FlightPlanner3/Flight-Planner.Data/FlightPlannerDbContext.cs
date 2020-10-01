using Flight_Planner.Core.Models;
using Flight_Planner.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Data
{//uzliku te public/
    public class FlightPlannerDbContext: DbContext, IFlightPlannerDbContext
    {
        public FlightPlannerDbContext() : base("flight-planner3")
        {
            Database.SetInitializer<FlightPlannerDbContext>(null);
            //kad realajaa dziivee uz ta pasa entity framework/
            //visdrizak nelaidis klat projekcijas db
            ///nodrosinas to ,ja bus jaunas migracijas, pie startapa
            //migracijas izplatisies ar jaunakajam migracijam
            //un lietotajs pat nemanis, ka kaut kas noticis
            //zelta rinda
            Database.SetInitializer<FlightPlannerDbContext>(new MigrateDatabaseToLatestVersion<FlightPlannerDbContext,Configuration>());
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        public System.Data.Entity.DbSet<Flight_Planner.Core.Models.Entity> Entities { get; set; }
    }
}
