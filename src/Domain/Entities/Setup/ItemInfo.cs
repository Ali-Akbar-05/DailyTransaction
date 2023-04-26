using Domain.Core;
using Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Setup
{
    public class ItemInfo :DeleteAbleEntity
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;
        public string? Description { get; private set;} = default!;
       
        public int? ParentId { get; private set; }
        public int NumberOfLevel { get; private set; }

       public int CompanyId { get; private set; }


        public List<InvoiceDetail>? InvoiceDetail { get; private set; }
        public UserCompany? UserCompany { get; private set; } = default!;
    }
}
