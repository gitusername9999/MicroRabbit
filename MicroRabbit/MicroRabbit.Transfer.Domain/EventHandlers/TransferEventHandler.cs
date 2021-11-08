using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _iTransferRepository;
        public TransferEventHandler(ITransferRepository iTransferRepository)
        {
            _iTransferRepository = iTransferRepository;
        }

        // This shoulbe invoked the the RabbitMQ bus
        public Task Handle(TransferCreatedEvent @event)
        {
            _iTransferRepository.Add(new TransferLog()
            {
                FromAccount = @event.FromAccount,
                ToAccount = @event.ToAccount,
                TransferAmount = @event.TransferAmount
            });

            return Task.CompletedTask;
        }
    }
}
