using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class ReaperDetail : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string HeadName { get; set; }
        public long ReaperId { get; set; }
        public long TransactionId { get; set; }
        public virtual Reaper Reaper { get; set; }

    }
}
