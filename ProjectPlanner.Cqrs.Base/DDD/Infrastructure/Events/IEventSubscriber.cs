namespace ProjectPlanner.Cqrs.Base.DDD.Infrastructure.Events
{
    public interface IEventSubscriber
    {
        void Subscribe(IEventListener listener);
        void Unsubscribe(IEventListener listener);
    }
}