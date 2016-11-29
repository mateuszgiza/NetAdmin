namespace NetAdmin.Infrastructure
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
