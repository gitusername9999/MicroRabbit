using MediatR;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MicroRabbit.Transfer.Domain.Events;

using System;
using System.Collections.Generic;
using System.Text;

// Injection objects container
namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        // RegisterService takes Interface to Collection of Services
        // Adding transient iServices of types specified in IEventBus, IAccountService, IAccountRepository, and BankingDbContext
        // with implementation type specified in RabbitMQBus, AccountService, and AccountRepository
        public static void RegisterServices(IServiceCollection iServices)
        {
            // Domain Bus
            iServices.AddTransient<IEventBus, RabbitMQBus>();

            // Domain Events
            iServices.AddTransient<IEventHandler<Transfer.Domain.Events.TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            iServices.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            //Application Services
            iServices.AddTransient<IAccountService, AccountService>();
            iServices.AddTransient<ITransferService, TransferService>();

            //Data
            iServices.AddTransient<IAccountRepository, AccountRepository>();
            iServices.AddTransient<ITransferRepository, TransferRepository>();
            iServices.AddTransient<BankingDbContext>();
            iServices.AddTransient<TransferDbContext>();

        }
    }
}
