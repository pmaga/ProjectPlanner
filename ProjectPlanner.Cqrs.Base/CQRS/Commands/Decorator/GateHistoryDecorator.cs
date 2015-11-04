using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Decorator
{
    public class GateHistoryDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _inner;

        public GateHistoryDecorator(ICommandHandler<TCommand> inner)
        {
            _inner = inner;
        }

        public void Handle(TCommand command)
        {
            _inner.Handle(command);
        }
    }
}
