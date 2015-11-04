using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands
{
    [Component]
    public class StandardGate : IGate
    {
        public RunEnvironment RunEnvironment { get; set; }

        public void Dispatch<T>(T command)
        {
            RunEnvironment.Run(command);
        }
    }
}
