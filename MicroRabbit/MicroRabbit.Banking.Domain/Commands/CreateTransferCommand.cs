using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Commands
{
    // TransferCommand is the based class for Transfer Commands
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand (int fromAcount, int toAcount, decimal transferAmount)
        {
            // assign the passed in variable fromAcount (containing info for source) toAcount variable FromAccount (the variable member of the
            // the based class TransferCommand)
            FromAccount = fromAcount;
            // assign the passed in variable toAcount (containing info for destination) toAcount variable ToAccount (the variable member of the
            // the based class TransferCommand)
            ToAccount = toAcount;
            // assign the passed in variable transferAmount toAcount variable TransferAmount (the variable member of the
            // the based class TransferCommand)
            TransferAmount = transferAmount;
        }
    }
}
