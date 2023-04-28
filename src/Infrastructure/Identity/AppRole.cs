using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppRole : IdentityRole
{
    public AppRole(string roleName):base(roleName)
    {
        
    }
    public bool IsSuperAdmin { get; set; }
    public DateTime CreateionDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int CompanyI { get;set; }
}
