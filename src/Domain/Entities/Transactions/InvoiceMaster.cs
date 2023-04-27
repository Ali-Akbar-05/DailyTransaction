using Domain.Core;
using Domain.Entities.Setup;

namespace Domain.Entities.Transactions;

public class InvoiceMaster : DeleteAggregate
{
    public int Id { get; private set; }
    public int TransactionTypeId { get; private set; }

    public DateTime TransactionDate { get; private set; }
    public int AccountId { get; private set; }

    public int PaymentTypeId { get; private set; }

    public string? Remarks { get; private set; } = default!;



    public List<InvoiceDetail> InvoiceDetail { get; private set; } = default!;
    public PaymentType PaymentType { get; private set; } = default!;
    public AccountInfo AccountInfo { get; private set; } = default!;
    public TransactionType TransactionType { get; private set; } = default!;

}
