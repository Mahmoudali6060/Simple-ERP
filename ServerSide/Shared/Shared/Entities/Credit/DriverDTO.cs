using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class DriverDTO : BaseEntity
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string CarPlate { get; set; }
        public virtual IEnumerable<TransferDTO> Transfers { get; set; }
        public virtual IEnumerable<OutcomeDTO> Outcomes { get; set; }


    }
}
