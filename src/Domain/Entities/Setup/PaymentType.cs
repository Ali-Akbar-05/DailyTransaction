using Domain.Core;

namespace Domain.Entities.Setup
{
    public class PaymentType : Entity
    {
        #region Property
        public int Id { get; private set; }
        public string Name { get; private set; } = default!;

        public int CompanyId { get; private set; }

        public virtual CompanyInfo CompanyInfo { get; private set; }
        #endregion


        #region Method
        public static PaymentType Create(string name, CompanyInfo companyInfo)
        {
            var paymentType = new PaymentType();
            paymentType.Name = name;
            if (companyInfo != null && !companyInfo.LockoutEnabled)
            {
                paymentType.CompanyId = companyInfo.Id;
            }
            else
            {
                throw new Exception("");
            }


            return paymentType;
        }

        #endregion
    }
}
