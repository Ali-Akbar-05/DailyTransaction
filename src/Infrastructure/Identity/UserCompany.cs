using Domain.Core;
using Domain.Entities.Setup;

namespace Infrastructure.Identity
{
    public class UserCompany : DeleteAbleEntity
    {
 

        public string UserId { get; private set; } = default!;

        public int CompanyId { get; private set; }
 
        public virtual CompanyInfo Company { get; private set; }
        public virtual AppUser User { get; private set; }
    }
}
