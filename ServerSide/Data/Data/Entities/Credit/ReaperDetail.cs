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
        public decimal TonPrice { get; set; }
        public decimal? PaidUp { get; set; }
        public DateTime? PaidDate { get; set; }
        public long ReaperId { get; set; }
        public long TransactionId { get; set; }

        public virtual Reaper Reaper { get; set; }


    }
}
