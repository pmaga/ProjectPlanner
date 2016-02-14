namespace ProjectPlannerASP5.Base.Cqrs.Base.DDD.Application
{
    public interface IApplicationEventPublisher
    {
        void Publish<T>(T eventData);
    }
}
