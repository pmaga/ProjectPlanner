using System;
using ProjectPlanner.Cqrs.Base.DDD.Application;

namespace ProjectPlanner.Projects.Tests.Mocks
{
    public class SystemUser : ISystemUser
    {
        public Guid UserId { get; private set; } = new Guid("edf05842-e174-4777-bb48-3c21ea177be2");

        public void SetUserId(Guid id)
        {
            UserId = id;
        }
    }
}
