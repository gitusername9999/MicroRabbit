using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _bankingDBContext;

        public AccountRepository (BankingDbContext bankingDBContext)
        {
            _bankingDBContext = bankingDBContext;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _bankingDBContext.Accounts;
            
        }
    }
}
