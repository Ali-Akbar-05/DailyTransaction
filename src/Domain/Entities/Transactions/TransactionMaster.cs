using Domain.Core;

namespace Domain.Entities.Transactions;

public class TransactionMaster : DeleteAbleEntity
{
    public int Id { get; private set; }
    public int TransactionTypeId { get; private set; }

    public DateTime TransactionDate { get; private set; }
    public int AccountId { get;private set; }

    public int PaymentTypeId { get; private set; }

    public string? Remarks { get; private set; } = default!;

}
