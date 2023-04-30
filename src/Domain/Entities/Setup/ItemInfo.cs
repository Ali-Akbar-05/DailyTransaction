using Domain.Core;
using Domain.Entities.Transactions;

namespace Domain.Entities.Setup
{
    public class ItemInfo : DeleteAbleEntity
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;
        public string? Description { get; private set; } = default!;

        public int? ParentId { get; private set; }
        public int NumberOfLevel { get; private set; }

        public int CompanyId { get; private set; }

        public bool HasChild { get; private set; } 

        public ItemInfo Parent { get; private set; }    
        public List<ItemInfo> ChildItem { get; private set; }

        public List<InvoiceDetail>? InvoiceDetail { get; private set; }
        public CompanyInfo? CompanyInfo { get; private set; } = default!;
    }
}
