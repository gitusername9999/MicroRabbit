using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Services
{
    // TransfersService class inherits TransferService Interface
    public class TransferService: ITransferService
    {
        // _iTransferRepository is an interface to Transfer Repository
        private readonly ITransferRepository _iTransferRepository;

        // Creating an event bus interface via independent injection to send the event to the RabbitMQ
        // Then inject it into our TransfeTService(ITransferRepository iTransferRepository)
        private readonly IEventBus _iEventBus;


        // TransferService constructor takes an interface to Transfer Repository, and injected interface for Event Bus from
        // the Domain Core Bus
        public TransferService(ITransferRepository iTransferRepository, IEventBus iEventBus)
        {            
            _iTransferRepository = iTransferRepository;
            _iEventBus = iEventBus;
        }

        // Implementing the GetTransferLogs method of TransferService class
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            // Calling the GetTransferLogs method residing in the transferlogs repository to get a list of transferlogs
            // respository interface is where we can access the operation of GetAccounts method.
            return _iTransferRepository.GetTransferLogs();
        }
    }
}
