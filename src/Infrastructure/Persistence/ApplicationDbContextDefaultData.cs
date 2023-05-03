using Domain.Entities.Setup;
using Domain.Enums;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextDefaultData
{
    private readonly ILogger<ApplicationDbContextDefaultData> _logger;
    private readonly ApplicationDbContext _dbCon;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public ApplicationDbContextDefaultData(ILogger<ApplicationDbContextDefaultData> logger,
       ApplicationDbContext dbCon,
       UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _logger = logger;
        _dbCon = dbCon;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task DatabaseInitialiseAsync()
    {
        try
        {
            if (_dbCon.Database.IsSqlServer())
            {
                await _dbCon.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"An Error occurred while initialising the database");
            throw new Exception(ex.Message);
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await AddSubscription();

            await AddCompany();



            await AddRole();
            await AddUser();
        }
        catch (Exception ex)
        {

        }
    }

    #region Setup
    private async Task AddSubscription()
    {
        var hasSubscription = await _dbCon.Subscription.AnyAsync();
        if (!hasSubscription)
        {
            _dbCon.Subscription.Add(Subscription.TestData(null, null));
          
            await _dbCon.SaveChangesAsync();
        }
    }
    private async Task AddCompany()
    {
        var hasCompany = await _dbCon.CompanyInfo.AnyAsync();
        if (!hasCompany)
        {
            var companyInfo = new List<CompanyInfo>();
            companyInfo.Add(CompanyInfo.TestData(null,null));
            companyInfo.Add(CompanyInfo.TestData("Safe Job",null));
            _dbCon.CompanyInfo.AddRange(companyInfo);
            await _dbCon.SaveChangesAsync();

        }
    }


    #endregion

    #region Identity
   
    private async Task AddRole()
    {
        var superAdmin = new AppRole(SystemRoles.superAdmin);
        superAdmin.IsSuperAdmin = true;
        if (_roleManager.Roles.All(r => r.Name != superAdmin.Name))
        {
            await _roleManager.CreateAsync(superAdmin);
        }

        var admin = new AppRole(SystemRoles.admin);
        admin.IsSuperAdmin = true;
        if (_roleManager.Roles.All(r => r.Name != admin.Name))
        {
            await _roleManager.CreateAsync(admin);
        }

        var manager = new AppRole(SystemRoles.manager);
        manager.IsSuperAdmin = false;
        if (_roleManager.Roles.All(r => r.Name != manager.Name))
        {
            await _roleManager.CreateAsync(manager);
        }

        var user = new AppRole(SystemRoles.user);
        user.IsSuperAdmin = false;
        if (_roleManager.Roles.All(r => r.Name != user.Name))
        {
            await _roleManager.CreateAsync(user);
        }
    }
     
    private async Task AddUser()
    {
        #region
        var superAdmin = new AppUser
        {
            UserName = "admin@safe.com",
            Email = "aliakbar.robintex@gmail.com",
            FirstName = "Md. Ali",
            LastName = "Akbar", 
        };
        if(_userManager.Users.All(u=>u.UserName!=superAdmin.UserName || u.Email != superAdmin.Email))
        {
            await _userManager.CreateAsync(superAdmin, "super!");
            await _userManager.AddToRoleAsync(superAdmin, SystemRoles.superAdmin);

            _dbCon.UserCompany.Add(UserCompany.Create(1,superAdmin.Id));
        }
        #endregion

        #region
        var admin = new AppUser
        {
            UserName = "jobayer@safe.com",
            Email = "jobayershoaib007@gmail.com",
            FirstName = "Jobayer",
            LastName = "Shoaib"
        };
        if (_userManager.Users.All(u => u.UserName != admin.UserName || u.Email != admin.Email))
        {
            await _userManager.CreateAsync(admin, "super!");
            await _userManager.AddToRoleAsync(admin, SystemRoles.admin);
            _dbCon.UserCompany.Add(UserCompany.Create(1, admin.Id));
        }
        #endregion
    }
    #endregion
}
