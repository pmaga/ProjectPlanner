using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainEntityAttribute : Attribute
    {
    }
}
