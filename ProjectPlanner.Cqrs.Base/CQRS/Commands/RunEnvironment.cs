using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands
{
    [Component]
    public class RunEnvironment
    {
        private readonly ICommandHandlerFactory _factory;

        public RunEnvironment(ICommandHandlerFactory factory)
        {
            _factory = factory;
        }

        public void Run<T>(T command)
        {
            ICommandHandler<T> handler = _factory.Create<T>();

            handler.Handle(command);
        }
    }
}
