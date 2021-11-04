using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.CommandHandlers
{
    // This where we need to use MediaR to communicate with RabbitMQ and handle our command
    // request
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        // IEventBus is the interface to the Event Bus in the Domain Core Bus (MicroRabbit.Domain.Core.Bus)
        private readonly IEventBus _iEventBus;

        // Constuctor TransferCommandHandler(IEventBus iEventBus) to initialize the eventBus interface with the passed in eventBus interface
        public TransferCommandHandler(IEventBus iEventBus)
        {
            _iEventBus = iEventBus;
        }

        // Implementing the interface for Request Handler to handle the request
        // Input: request is of CreateTransferCommand, and it is the command requested to be performed / handled
        // Input: cancellationToken is of type CancellationToken, and it is used to cancell the request
        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            // The idea is that customers will log in, and they will have a chance to view all their
            // account information through out banking microservices as well as initiating a transfer.
            // A transfer is a command that our microservice will send through the event bus, and this command (event) is
            // a requested command which will be handled by our transfer event handler (Handle (...)), and our transfer event handler
            // (Handle(...), will then publish the requested event (requested command) to RabbitMQ Service
            // RabbitMQ will hold the requested event until any subscriber who subscripes to this event and consumes it.

            // Publishing requested event to RabbitMQ serverice
            // We could have ceate a TransferCreatedEvent to just take a request object instead of its data properties
            _iEventBus.Publish(new TransferCreatedEvent(request.FromAccount, request.ToAccount, request.TransferAmount));


            return Task.FromResult(true);
        }
    }
}
 