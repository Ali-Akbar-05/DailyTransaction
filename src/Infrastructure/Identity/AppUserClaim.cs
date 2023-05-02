﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppUserClaim :IdentityUserClaim<string>
    {
        public virtual AppUser User { get; set; }
    }
}
