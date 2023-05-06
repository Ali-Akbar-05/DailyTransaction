using Domain.Entities.Setup;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? ImageSrc { get; set; }  

    public bool IsActive { get; set; }
    public DateTime CreateionDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<AppUserClaim> Claims { get; set; }
    public virtual ICollection<AppUserLogin> Logins { get; set; }
    public virtual ICollection<AppUserToken> Tokens { get; set; }
    public virtual ICollection<AppUserRole> UserRoles { get; set; }

 
    




}
