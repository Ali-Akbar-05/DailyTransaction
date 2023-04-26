using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transactions
{
    public class TransactionDetail :DeleteAbleEntity
    {
        public long Id { get; private set; } 
        public int MasterId { get; private set; }
        public int AccountId { get; private set; }  
        public decimal? Rate { get; private set; }
        public decimal? Quantity { get; private set; }
        public decimal Amount { get; private set; }
    }
}
