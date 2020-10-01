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
    public class DbService : IDbService
    {
        protected readonly IFlightPlannerDbContext _ctx;


        public DbService(IFlightPlannerDbContext context)
        {
            _ctx = context;
        }
        public ServiceResult Create<T>(T entity) where T : Entity
        {
            if (entity == null) 
            {
                throw new ArgumentException(nameof(entity));
            }
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);//ar set pasaka kura tabula
        }
        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
            return new ServiceResult(true);
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return QueryById<T>(id).Any();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Query<T>().ToList();
        }

        public async Task<T> GetById<T>(int id) where T : Entity
        {
            return await _ctx.Set<T>()
                 .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _ctx.Set<T>().Where(e => e.Id == id);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            _ctx.Entry(entity).State = EntityState.Modified;
            //pie sav tas izm tiks saglabatas
            _ctx.SaveChanges();

            return new ServiceResult(true).Set(entity);
        }
    }
}
