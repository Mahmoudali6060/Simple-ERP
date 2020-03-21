using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class SelectorDetail : BasicsData
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string HeadName { get; set; }
        public long TransactionId { get; set; }
        public long SelectorId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual Selector Selector { get; set; }
    }
}
