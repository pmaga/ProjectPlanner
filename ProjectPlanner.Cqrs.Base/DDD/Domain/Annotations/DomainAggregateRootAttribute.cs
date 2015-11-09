using System;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainAggregateRootAttribute : DomainEntityAttribute
    {
    }
}
