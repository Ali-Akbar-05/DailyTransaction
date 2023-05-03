using Domain.Core;
using System.Xml.Linq;

namespace Domain.Entities.Setup;

public class Subscription : AuditableEntity
{
    public int Id { get; private set; }
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public int ConditinalDayes { get; private set; } = default!;



    public static Subscription Create(string code,string name,string ?description,int conditionaldayes=30)
    {
        Subscription subscription = new Subscription();
        subscription.Code = code;   
        subscription.Name = name;   
        subscription.Description = description; 
        subscription.ConditinalDayes = conditionaldayes;
        return subscription;
    } 

    public static Subscription TestData(string? code,string? name)
    {
        Subscription subscription = new Subscription();
        subscription.Code =code??"SYS-01";
        subscription.Name =name??"OWN Subscription";
        subscription.Description = "Internal Subscripiton";
        subscription.ConditinalDayes = 365;
 
        return subscription;
    }

}
