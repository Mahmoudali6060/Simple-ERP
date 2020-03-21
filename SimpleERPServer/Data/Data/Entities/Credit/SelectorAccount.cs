using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class SelectorAccount : BaseAccount
    {
        public long SelectorId { get; set; }
        public virtual Selector Selector { get; set; }
    }
}
