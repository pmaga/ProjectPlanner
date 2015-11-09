namespace ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        void Handler(TCommand command);
    }
}
