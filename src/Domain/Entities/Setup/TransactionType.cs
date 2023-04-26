using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Setup;

public class TransactionType:Entity
{ 
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;


    public string MathematicalType { get; private set; } = default!;

    public int CompanyId { get; private set; }

}
