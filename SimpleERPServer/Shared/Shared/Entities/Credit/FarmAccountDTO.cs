using Data.Entities.Shared;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class FarmAccountDTO : BaseAccount
    {
        public long FarmId { get; set; }
        public virtual FarmDTO Farm { get; set; }
    }
}
