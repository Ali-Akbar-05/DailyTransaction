using Domain.Core;
using Domain.Entities.Setup;

namespace Infrastructure.Identity
{
    public class UserCompany : DeleteAbleEntity
    {
<<<<<<< HEAD

        public string UserId { get; private set; } = default!;

        public int CompanyId { get; private set; }

=======
        public string UserId { get; private set; }
        public int CompanyId { get; private set; }

>>>>>>> 7f26b961af687cdc2cb06db1f3fc0ab0145db5e3
        public virtual CompanyInfo Company { get; private set; }
        public virtual AppUser User { get; private set; }
    }
}
