using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Events; // needed for Command


namespace MicroRabbit.Domain.Core.Bus
{
    // This event handler can take in any type of event, and it implements IEventHandler where the event that comes
    // in has to be of type Event
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);

    }

    public interface IEventHandler
    {

    }
}
