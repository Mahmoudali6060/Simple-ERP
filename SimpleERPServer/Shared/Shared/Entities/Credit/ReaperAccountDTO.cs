using Data.Entities.Shared;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class ReaperAccountDTO : BaseAccount
    {
        public long ReaperId { get; set; }
        public virtual ReaperDTO Reaper { get; set; }
    }
}
