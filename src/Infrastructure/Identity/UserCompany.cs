using Domain.Core;
using Domain.Entities.Setup;

namespace Infrastructure.Identity
{
    public class UserCompany : DeleteAbleEntity
    {
        public string UserId { get; private set; }
        public string CompanyId { get; private set; }

        public virtual CompanyInfo CompanyInfo { get; private set; }
        public virtual AppUser AppUser { get; private set; }
    }
}
