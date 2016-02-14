using System;

namespace ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DomainFactoryAttribute : Attribute
    {
    }
}
