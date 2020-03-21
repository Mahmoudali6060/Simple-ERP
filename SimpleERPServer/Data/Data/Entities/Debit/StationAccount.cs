using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Debit
{
    public class StationAccount : BaseAccount
    {
        public long StationId { get; set; }
        public virtual Station Station { get; set; }
    }
}
