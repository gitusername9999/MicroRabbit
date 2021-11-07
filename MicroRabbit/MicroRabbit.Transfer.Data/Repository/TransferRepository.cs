using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Transfer.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _transferDBContext;

        public TransferRepository (TransferDbContext bankingDBContext)
        {
            _transferDBContext = bankingDBContext;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferDBContext.TransferLogs;
            
        }
    }
}
