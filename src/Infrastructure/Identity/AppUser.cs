﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? ImageSrc { get; set; } 
    public int CompanyId { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreateionDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
