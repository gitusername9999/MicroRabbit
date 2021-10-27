using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Domain.Core.Events
{
    // this class implements IReques
    // This request is expecting a boolean back
    public abstract class Message : IRequest<bool>
    {
        // Since it is an abstract, we declared as a protected set
        public string MessageType { get; protected set; }

        // Constructor for message
        protected Message()
        {
            // Using reflection get type of the message
            MessageType = GetType().Name;
        }
    }
}
