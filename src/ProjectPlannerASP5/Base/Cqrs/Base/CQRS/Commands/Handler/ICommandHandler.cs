namespace ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands.Handler
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        void Handle(TCommand command);
    }
}
