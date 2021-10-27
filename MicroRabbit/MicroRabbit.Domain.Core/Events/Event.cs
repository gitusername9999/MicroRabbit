using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Domain.Core.Events
{
    // this is our base event class
    public abstract class Event
    {
        public DateTime TimeStamp { get; protected set; }

        // Constructor for the Event
        // Protect because is in the abstract class and only one inherits this class can set event timestamp
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
