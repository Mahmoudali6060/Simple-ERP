using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class DriverAccount : BaseAccount
    {
        public long DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
