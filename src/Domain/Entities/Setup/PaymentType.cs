using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Setup
{
    public class PaymentType:Entity
    {
        public int Id { get;private set; }
        public string Name { get; private set; }=default!;


    }
}
