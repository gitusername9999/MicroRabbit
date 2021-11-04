using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Commands; // needed for Command
using MicroRabbit.Domain.Core.Events; // needed for Event


namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T Command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, IEH>()
            where T : Event       // T is of type Event
            where IEH : IEventHandler<T>; // IEH is of type IEventHandler of type T

    }
}
