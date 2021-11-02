using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Events
{
    // TransferCreatedEvent extends or inherited based Event class from Domain Core Event
    public class TransferCreatedEvent : Event
    {
        // Declare set as private so no one touch this event except internal methods
        // Declare get as public so that other can get data
        public int From { get; private set; }
        public int To { get; private set; }
        public decimal Amount { get; private set; }

        // Creating a constructor TransferCreatedEvent to create a TransferCreatedEvent
        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
