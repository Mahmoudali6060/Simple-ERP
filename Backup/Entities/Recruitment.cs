using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Recruitment
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
