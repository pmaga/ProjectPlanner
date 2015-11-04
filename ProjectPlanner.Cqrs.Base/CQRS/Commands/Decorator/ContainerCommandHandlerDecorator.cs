using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Decorator
{
    public class ContainerCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandlerFactory _factory;
        public ContainerCommandHandlerDecorator(ICommandHandlerFactory factory)
        {
            _factory = factory;
        }

        public void Handle(TCommand command)
        {
            ICommandHandler<TCommand> handler = null;

            try
            {
                ICommandHandler commandHandler = _factory.CreateByName(command.GetType().FullName);

                handler = (ICommandHandler<TCommand>)commandHandler;
                handler.Handle(command);
            }
            finally
            {
                if (handler != null)
                {
                    _factory.Release(handler);
                }
            }
        }
    }
}
