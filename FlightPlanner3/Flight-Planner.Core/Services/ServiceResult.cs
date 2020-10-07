
using Flight_Planner.Core.Interfaces;
using System.Collections.Generic;

namespace Flight_Planner.Core.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; }
        public int Id { get; }
        public IEntity Entity { get; private set; }

        public ServiceResult(int id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }
        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public ServiceResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }
    }
}
