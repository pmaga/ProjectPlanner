using System;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DomainFactoryAttribute : Attribute
    {
    }
}
