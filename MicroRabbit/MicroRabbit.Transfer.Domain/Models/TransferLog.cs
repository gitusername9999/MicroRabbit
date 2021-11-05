using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int FromAcount { get; set; }
        public int ToAcount { get; set; }
        public decimal TransferAmount { get; set; }

    }
}
