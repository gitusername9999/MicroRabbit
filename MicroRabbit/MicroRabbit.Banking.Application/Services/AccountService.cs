using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Services
{
    // AccountService class inherits AccountService Interface
    public class AccountService: IAccountService
    {
        // _iAccountRepository is an interface to Account Repository
        private readonly IAccountRepository _iAccountRepository;

        // Creating an event bus interface via independent injection to send the event to the RabbitMQ
        // Then inject it into our AccouunService constructor 
        // public AccountService(IAccountRepository iAccountRepository)
        private readonly IEventBus _iEventBus; 


        // AccountService constructor takes an interface to Account Repository, and injected interface for Event Bus from
        // the Domain Core Bus
        public AccountService(IAccountRepository iAccountRepository, IEventBus iEventBus)
        {            
            _iAccountRepository = iAccountRepository;
            _iEventBus = iEventBus;
        }

        // Implementing the GetAccounts method of AccountService class
        public IEnumerable<Account> GetAccounts()
        {
            // Calling the GetAccounts method residing in the account repository to get a list of accounts
            // respository interface is where we can access the operation of GetAccounts method.
            return _iAccountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            // Creating a account transfer command
            var createTransferCommand = new CreateTransferCommand
                (
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            // Using the injected Event Bus from Domain Core Bus to send command(s) to RabbitMQ
            // Since out SendCommand takes a generic type, it can take and send any type of command
            // In this case, we send a createTransferCommand
            _iEventBus.SendCommand(createTransferCommand);
        }
    }
}
