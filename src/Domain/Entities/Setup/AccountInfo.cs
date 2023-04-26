using Domain.Core;

namespace Domain.Entities.Setup;

public class AccountInfo : DeleteAbleEntity
{
    public int Id { get; private set; }
    public string IdentificationNo { get; private set; } = default!;

    public string? Name { get; private set; } = default!;
    public string? MobileNo { get; private set; } = default!;
    public int? ParentId { get; private set; }

    public int Level { get; private set; }
    public int CompanyId { get; private set; }


}
