using Domain.Primitives.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class AuditAggregate : Aggregate, IAuditableEntity
    {
        public DateTime? LastModified { get; protected set; } = default!;

        public int? LastModifiedBy { get; protected set; } = default!;
    }
}
