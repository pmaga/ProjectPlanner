namespace ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands
{
    public interface IGate
    {
        void Dispatch<T>(T command);
    }
}
