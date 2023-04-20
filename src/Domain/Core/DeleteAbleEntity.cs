using Domain.Primitives.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class DeleteAbleEntity : AuditableEntity, IHaveSoftDelete
    {
        public bool IsDeleted { get; private set; } 

        public DateTime? DeletedDate { get; private set; } = default!;

        public int? DeletedBy { get; private set; } = default!;
    }
}
