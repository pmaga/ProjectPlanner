using System.Runtime.InteropServices.ComTypes;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();
        ICommandHandler CreateByName(string name);

        void Release(ICommandHandler handler);
    }
}
