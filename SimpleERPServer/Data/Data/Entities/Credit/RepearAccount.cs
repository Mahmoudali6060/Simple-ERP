using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class ReaperAccount : BaseAccount
    {
        public long ReaperId { get; set; }
        public virtual Reaper Reaper { get; set; }
    }
}
