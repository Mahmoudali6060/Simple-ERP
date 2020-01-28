using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class ReaperDetailDTO : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal TonPrice { get; set; }
        public decimal PaidUp { get; set; }
        public DateTime PaidDate { get; set; }
        public long ReaperId { get; set; }
        public virtual ReaperDTO Reaper { get; set; }


    }
}
