using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands
{
    [Component]
    public class StandardGate : IGate
    {
        private readonly RunEnvironment _runEnvironment;

        public StandardGate(RunEnvironment runEnvironment)
        {
            _runEnvironment = runEnvironment;
        }

        public void Dispatch<T>(T command)
        {
            _runEnvironment.Run(command);
        }
    }
}