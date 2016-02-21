using System;

namespace ProjectPlanner.Cqrs.Base.Infrastructure.Attributes
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
