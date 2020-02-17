using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class SelectorDetailDTO : BasicsData
    {
        public long TransactionId { get; set; }
        public long SelectorId { get; set; }
        public virtual TransactionDTO Transaction { get; set; }
        public virtual SelectorDTO Selector { get; set; }
    }
}
