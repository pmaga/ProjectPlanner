using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.CQRS.Query.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FinderAttribute : Attribute
    {
    }
}
