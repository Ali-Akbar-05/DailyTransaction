using Domain.Core;
using Domain.Entities.Transactions;

namespace Domain.Entities.Setup;

public class AccountInfo : DeleteAbleEntity
{
    public int Id { get; private set; }
    public string IdentificationNo { get; private set; } = default!;

    public string? Name { get; private set; } = default!;
    public string? MobileNo { get; private set; } = default!;
    public string? Email { get; private set; } = default!;
    public int? ParentId { get; private set; }

    public int Level { get; private set; } 

    public int CompanyId { get; private set; }


    public UserCompany UserCompany { get; private set; } = default!;
    public List<InvoiceMaster>? InvoiceMaster { get; private set; } 

}
