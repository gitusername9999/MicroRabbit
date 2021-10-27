using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Domain.Core.Commands
{
    // Command of type Message
    public abstract class Command : Message
    {
        // Only ones that inherited this cass can set the Timestamp of this abstract Command class so we set it to protected set
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
