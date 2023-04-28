using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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
       UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
    {
        _logger = logger;
        _dbCon = dbCon;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task DefaultDataAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }

    public async Task SeedAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }

    #region Setup



    #endregion

    #region Identity


    #endregion
}
