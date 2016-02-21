using System;

namespace ProjectPlanner.Cqrs.Base.DDD.Application
{
    public interface ISystemUser
    {
        Guid UserId { get; }
    }
}
