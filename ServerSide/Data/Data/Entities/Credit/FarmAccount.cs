using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class FarmAccount : BaseAccount
    {
        public long FarmerId { get; set; }
        public virtual Farm Farm { get; set; }
    }
}
