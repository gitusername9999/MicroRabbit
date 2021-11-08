using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Commands
{
    // TransferCommand is the based class for Transfer Commands
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand (int fromAccount, int toAccount, decimal transferAmount)
        {
            // assign the passed in variable fromAccount (containing info for source account) to variable fromAccount (the variable member of the
            // the based class TransferCommand)
            FromAccount = fromAccount;
            // assign the passed in variable toAccount (containing info for destination account) to variable toAccount (the variable member of the
            // the based class TransferCommand)
            ToAccount = toAccount;
            // assign the passed in variable transferAmount (containing info for destination account) to variable TransferAmount (the variable member of the
            // the based class TransferCommand)
            TransferAmount = transferAmount;
        }
    }
}
