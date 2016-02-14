using System;

namespace ProjectPlannerASP5.Base.Cqrs.Base.Infrastructure.Attributes
{
    public class ComponentAttribute : Attribute
    {
        public ComponentLifestyle ComponentLifestyle { get; set; }

        public ComponentAttribute()
            : this(ComponentLifestyle.Singleton)
        {
        }

        public ComponentAttribute(ComponentLifestyle lifestyle)
        {
            ComponentLifestyle = lifestyle;
        }
    }
}
