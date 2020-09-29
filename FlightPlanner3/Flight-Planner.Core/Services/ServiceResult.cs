
using Flight_Planner.Core.Interfaces;
using System.Collections.Generic;

namespace Flight_Planner.Core.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; } //negribam,lai pa celam kads kko maina pa celam, tapec private
        public int Id { get; }

        public IEntity Entity { get; private set; }

        //taisam metodi kas atgriež pašu klasi
        //var viegli mainit objektu jo atgriež sevi atpakaļ
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
