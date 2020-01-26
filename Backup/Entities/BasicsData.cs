using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BasicsData : BaseEntity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Withdraws { get; set; }
        public decimal Pay { get; set; }
        public decimal Balance { get; set; }
    }
}
