using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class FarmDTO : BaseEntity
    {
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<IncomeDTO> Incomes { get; set; }
        public virtual IEnumerable<TransferDTO> Transfers { get; set; }
    }
}
