using System;
using System.Collections.Generic;
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
        public ServiceResult Create<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public bool Exists<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
