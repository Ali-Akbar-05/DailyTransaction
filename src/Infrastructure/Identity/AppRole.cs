using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppRole : IdentityRole<int>
{
    public AppRole(string roleName):base(roleName)
    {
        
    }
    public bool IsSuperAdmin { get; set; }
    public DateTime CreateionDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
