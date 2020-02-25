using Data.Entities.Shared;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Debit
{
    public class StationAccountDTO : BaseAccount
    {
        public long StationId { get; set; }
        public virtual StationDTO Station { get; set; }
    }
}
