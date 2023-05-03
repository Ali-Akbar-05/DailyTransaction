using Domain.Core;
using System.Net.NetworkInformation;

namespace Domain.Entities.Setup;

public class CompanyInfo : AuditableEntity
{

    public int Id { get; private set; }
    public  string Code { get; private set; } = default!;
    /// <summary>
    /// Get Company name
    /// </summary>
    public string CompanyName { get; private set; } = default!;

    public string? CompanyLogo { get; private set; } = default!;

    public bool IsActive { get; private set; }

    /// <summary>
    /// Gets or sets a flag indicating if the company could be locked out.
    /// </summary>
    /// <value>True if the company could be locked out, otherwise false.</value>
    public bool LockoutEnabled { get; set; }

    /// <summary>
    /// Gets or sets the date and time, in UTC, when any company lockout ends.
    /// </summary>
    /// <remarks>
    /// A value in the past means the company is not locked out.
    /// </remarks>
    public DateTime? LockoutEnd { get; set; }

    public int SubscriptionId { get; private set; }

    public DateTime? SubscriptionEndDate { get; private set; }


    public Subscription Subscription { get; private set; } = default!;



    public static CompanyInfo Create(string code,string companyName, string companyLogo)
    {
        var companyInfo = new CompanyInfo(); 
        companyInfo.CompanyLogo = companyLogo;
        companyInfo.IsActive=true;
        companyInfo.LockoutEnabled = false;
        companyInfo.SubscriptionId = 1;
        companyInfo.SubscriptionEndDate= DateTime.Now.AddYears(1);
        return companyInfo; ;
    }

    public static CompanyInfo TestData(string? companyName, string? companyLogo)
    {
        var companyInfo = new CompanyInfo();
        companyInfo.CompanyName = companyName?? "Safe";
        companyInfo.IsActive = true;
        companyInfo.LockoutEnabled = false;
        companyInfo.SubscriptionId = 1;
        companyInfo.SubscriptionEndDate = DateTime.Now.AddDays(Subscription.TestData(null,null).ConditinalDayes);

        return companyInfo; ;
    }
}

