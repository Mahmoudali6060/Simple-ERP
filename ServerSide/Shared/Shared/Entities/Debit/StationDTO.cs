using Shared.Entities.Credit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Debit
{
    public class StationDTO : BaseEntity
    {
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<OutcomeDTO> Outcomes { get; set; }
        public virtual IEnumerable<TransferDTO> Transfers { get; set; }

    }
}
