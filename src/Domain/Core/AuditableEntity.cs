using Domain.Primitives.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class AuditableEntity : Entity, IAuditableEntity
    {
        public DateTime? LastModified { get;private set; } = default!;

        public int? LastModifiedBy { get; private set; } = default!;
        public int MofificationNumber { get; private set; }    
    }
}
