using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class SelectorDetailDTO : BasicsData
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string HeadName { get; set; }
        public long TransactionId { get; set; }
        public long SelectorId { get; set; }
        public virtual TransactionDTO Transaction { get; set; }
        public virtual SelectorDTO Selector { get; set; }
    }
}
