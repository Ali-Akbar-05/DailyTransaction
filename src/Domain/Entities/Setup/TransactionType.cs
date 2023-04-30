using Domain.Core;
using Domain.Enums;

namespace Domain.Entities.Setup;

public class TransactionType : Entity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;


    public MathematicalType MathematicalType { get; private set; } = default!;

    public int CompanyId { get; private set; }

}


