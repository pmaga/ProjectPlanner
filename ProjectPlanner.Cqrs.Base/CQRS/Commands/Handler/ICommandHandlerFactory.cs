using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();
        ICommandHandler CreateByName(string name);

        void Release(ICommandHandler handler);
    }
}
