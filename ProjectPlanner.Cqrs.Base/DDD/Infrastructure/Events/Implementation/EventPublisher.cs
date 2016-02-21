using System.Collections.Generic;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Cqrs.Base.DDD.Infrastructure.Events.Implementation
{
    public class EventPublisher : IEventSubscriber, IDomainEventPublisher, IApplicationEventPublisher
    {
        private HashSet<IEventListener> _eventHandlers = new HashSet<IEventListener>();
        private readonly object _lock = new object();

        public void Subscribe(IEventListener listener)
        {
            lock (_lock)
            {
                var eventHandlers = new HashSet<IEventListener>(_eventHandlers)
                {
                    listener
                };

                _eventHandlers = eventHandlers;
            }
        }

        public void Unsubscribe(IEventListener listener)
        {
            lock (_lock)
            {
                var eventHandlers = new HashSet<IEventListener>(_eventHandlers);
                eventHandlers.Remove(listener);
                _eventHandlers = eventHandlers;
            }
        }

        void IDomainEventPublisher.Publish<T>(T domainEvent)
        {
            PublishInternal(domainEvent);
        }

        void IApplicationEventPublisher.Publish<T>(T applicationEvent)
        {
            PublishInternal(applicationEvent);
        }

        protected void PublishInternal<T>(T eventObject)
        {
            foreach (var eventHandler in _eventHandlers)
            {
                if (eventHandler is IEventListener<T>)
                {
                    ((IEventListener<T>)eventHandler).Handle(eventObject);
                }
            }
        }
    }
}
