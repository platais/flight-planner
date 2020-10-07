using Flight_Planner.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Data
{
    public interface IFlightPlannerDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T: class;
        int SaveChanges();
        Task<int> SaveChangesAsync();

        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }
    }
}
