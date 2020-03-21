using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class Farm : BaseEntity
    {
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<Income> Incomes { get; set; }
        public virtual IEnumerable<Transfer> Transfers { get; set; }
    }
}
