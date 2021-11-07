using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Events
{
    // TransferCreatedEvent extends or inherited based Event class fromAccount Domain Core Event
    public class TransferCreatedEvent : Event
    {
        // Declare set as private so no one touch this event except internal methods
        // Declare get as public so that other can get data
        public int FromAccount { get; private set; }
        public int ToAccount { get; private set; }
        public decimal TransferAmount { get; private set; }

        // Creating a constructor TransferCreatedEvent toAccount create a TransferCreatedEvent
        public TransferCreatedEvent(int fromAccount, int toAccount, decimal transferAmount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferAmount = transferAmount;
        }
    }
}
