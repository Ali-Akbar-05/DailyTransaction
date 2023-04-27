using Domain.Primitives.Common.Abstractions;

namespace Domain.Core
{
    public class DeleteAbleEntity : AuditableEntity, IHaveSoftDelete
    {
        public bool IsDeleted { get; private set; }

        public DateTime? DeletedDate { get; private set; } = default!;

        public string? DeletedBy { get; private set; } = default!;
    }
}
