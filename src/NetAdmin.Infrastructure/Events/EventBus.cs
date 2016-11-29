using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAdmin.Infrastructure
{
    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;

        public EventBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _handlersFactory(typeof(TEvent))
                .Cast<IHandleEvent<TEvent>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
