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
            throw new NotImplementedException();
        }

        public ServiceResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
