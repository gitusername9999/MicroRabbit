using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Commands
{
    // TransferCommand is the based class for Transfer Commands
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand (int from, int to, decimal amount)
        {
            // assign the passed in variable from (containing info for source) to variable From (the variable member of the
            // the based class TransferCommand)
            From = from;
            // assign the passed in variable to (containing info for destination) to variable To (the variable member of the
            // the based class TransferCommand)
            To = to;
            // assign the passed in variable amount to variable Amount (the variable member of the
            // the based class TransferCommand)
            Amount = amount;
        }
    }
}
