using Domain.Core;
using Domain.Entities.Setup;

namespace Domain.Entities.Transactions
{
    public class InvoiceDetail : DeleteAbleEntity
    {
        public long Id { get; private set; }
        public int MasterId { get; private set; }
        public int? ItemId { get; private set; }
        public decimal? Rate { get; private set; }
        public decimal? Quantity { get; private set; }
        public decimal Amount { get; private set; }



        public InvoiceMaster InvoiceMaster { get; private set; } = default!;
        public ItemInfo ItemInfo { get; private set; } = default!;
    }
}
