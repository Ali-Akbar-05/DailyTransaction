using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Login.DTO
{
    public class UserResponse
    {
        public string UserId { get; set; } = default!;
        public string UserName { get; set; } = default!;    
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<string>? Roles { get; set; }

        public int CompanyId { get; set; }
    }
}
