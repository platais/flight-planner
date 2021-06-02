using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flight_Planner.Services
{
    public class EntityService<T>: DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public bool Exists(int id)
        {
            return Exists<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public Task<T> GetById(int id)
        {
            return GetById<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            return QueryById<T>(id);
        }

        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }
    }
}
