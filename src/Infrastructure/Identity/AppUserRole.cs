using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppUserRole :IdentityUserRole<string>
    {
        public virtual AppUser User { get; set; }    
        public virtual AppRole Role { get; set; }
    }
}
