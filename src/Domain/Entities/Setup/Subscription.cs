using Domain.Core;

namespace Domain.Entities.Setup;

public class Subscription : AuditableEntity
{
    public int Id { get; private set; }
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public int ConditinalDayes { get; private set; } = default!;
}
