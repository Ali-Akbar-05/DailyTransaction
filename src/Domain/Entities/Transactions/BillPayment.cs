using Domain.Core;
using Domain.Entities.Setup;

namespace Domain.Entities.Transactions
{
    public class BillPayment : DeleteAbleEntity
    {


        #region Property

        public int Id { get; private set; }
        public int InvoiceMasterId { get; private set; }
        public int? PaymentTypeId { get; private set; }
        public string? PaymentHints { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal PaymentAmount { get; private set; }
        public decimal WaiverAmount { get; private set; }

        public string? Remarks { get; private set; } = default!;

        public PaymentType? PaymentType { get; private set; } 
        public InvoiceMaster? InvoiceMaster { get; private set; }

        #endregion  Property

        #region Method

        public static BillPayment Create(int invoiceMasterId, int? paymentTypeId, string? paymentHints, DateTime paymentDate, decimal paymentAmount, decimal waiverAmount, string? remarks)
        {
            BillPayment billPayment = new BillPayment();
            billPayment.InvoiceMasterId = invoiceMasterId;
            billPayment.PaymentTypeId = paymentTypeId;
            billPayment.PaymentHints = paymentHints;
            billPayment.PaymentDate = paymentDate;
            billPayment.PaymentAmount = paymentAmount;
            billPayment.WaiverAmount = waiverAmount;
            billPayment.Remarks = remarks;
            return billPayment;
        }
        #endregion
    }
}
