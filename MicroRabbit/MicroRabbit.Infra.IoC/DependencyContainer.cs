using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Ranking.Data.Context;
using MicroRabbit.Ranking.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
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

            // Domain Banking Commands
            iServices.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            iServices.AddTransient<IAccountService, AccountService>();

            //Data
            iServices.AddTransient<IAccountRepository, AccountRepository>();
            iServices.AddTransient<BankingDbContext>();

        }
    }
}
