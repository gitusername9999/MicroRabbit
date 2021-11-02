using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Services
{
    // AccountService class inherits AccountService Interface
    public class AccountService: IAccountService
    {
        // _accountRepository is an interface to Account Repository
        private readonly IAccountRepository _accountRepository;

        // AccountService constructor takes an interface to Account Repository
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Implementing the GetAccounts method of AccountService class
        public IEnumerable<Account> GetAccounts()
        {
            // Calling the GetAccounts method residing in the account repository to get a list of accounts
            // respository interface is where we can access the operation of GetAccounts method.
            return _accountRepository.GetAccounts();
        }
    }
}
