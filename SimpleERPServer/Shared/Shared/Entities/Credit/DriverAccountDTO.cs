using Data.Entities.Shared;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class DriverAccountDTO : BaseAccount
    {
        public long DriverId { get; set; }
        public virtual DriverDTO Driver { get; set; }
    }
}
