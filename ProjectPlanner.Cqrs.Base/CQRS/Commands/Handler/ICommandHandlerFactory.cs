namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();

        void Release(ICommandHandler handler);
    }
}
