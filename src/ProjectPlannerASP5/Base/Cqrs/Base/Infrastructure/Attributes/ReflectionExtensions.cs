using System;
using System.Linq;

namespace ProjectPlannerASP5.Base.Cqrs.Base.Infrastructure.Attributes
{
    public static class ReflectionExtensions
    {
        public static bool IsComponentLifestyle(this Type type, ComponentLifestyle lifestyle)
        {
            var attribute = type.GetCustomAttributes(typeof(ComponentAttribute), true)
                .OfType<ComponentAttribute>()
                .FirstOrDefault();

            return attribute?.ComponentLifestyle == lifestyle;
        }
    }
}
