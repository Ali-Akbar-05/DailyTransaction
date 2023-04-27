using Domain.Primitives.Common.Abstractions;

namespace Domain.Core
{
    public abstract class Entity : IEntity
    {
        public   DateTime CreatedDate { get; private set; } = default!;
        public   string CreatedBy { get; private set; } = default!;


    }
}
