using Domain.Entities.Setup;

namespace Domain.Utility;
public static class DefaultSetupData
{
    public static class PaymentTypeData
    {
        public static List<Domain.Entities.Setup.PaymentType> Initial(CompanyInfo companyInfo)
        {
            var data = new List<Domain.Entities.Setup.PaymentType>();

            data.Add(PaymentType.Create("Cash", companyInfo));
            data.Add(PaymentType.Create("Moble", companyInfo));
            return data;
        }
    }

}
