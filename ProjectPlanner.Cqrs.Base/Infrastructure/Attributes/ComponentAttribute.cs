using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.Infrastructure.Attributes
{
    public class ComponentAttribute : Attribute
    {
        public ComponentLifestyle LifeStyle { get; set; }
        public bool Start { get; set; }

        public ComponentAttribute()
            : this(ComponentLifestyle.Singleton)
        {
        }

        public ComponentAttribute(ComponentLifestyle lifeStyle)
            : this(lifeStyle, false)
        {
        }

        public ComponentAttribute(ComponentLifestyle lifeStyle, bool start)
        {
            LifeStyle = lifeStyle;
            Start = start;
        }
    }
}
