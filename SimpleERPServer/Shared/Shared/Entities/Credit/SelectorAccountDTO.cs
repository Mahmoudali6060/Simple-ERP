using Data.Entities.Shared;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class SelectorAccountDTO : BaseAccount
    {
        public long SelectorId { get; set; }
        public virtual SelectorDTO Selector { get; set; }
    }
}
