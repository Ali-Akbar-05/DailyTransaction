using Domain.Primitives.Common.Abstractions;

namespace Domain.Core
{
    public abstract class Entity : IEntity
    {
        public   DateTime CreatedDate { get; private set; } = default!;
        public   int CreatedBy { get; private set; } = default!;


    }
}
