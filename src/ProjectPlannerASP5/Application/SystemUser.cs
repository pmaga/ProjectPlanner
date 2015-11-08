using System;
using ProjectPlanner.Cqrs.Base.DDD.Application;

namespace ProjectPlannerASP5.Application
{
    public class SystemUser : ISystemUser
    {
        public Guid UserId => new Guid("edf05842-e174-4777-bb48-3c21ea177be2");
    }
}
