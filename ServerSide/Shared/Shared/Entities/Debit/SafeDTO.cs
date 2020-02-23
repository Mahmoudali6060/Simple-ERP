using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Debit
{
    public class SafeDTO : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Incoming { get; set; }
        public decimal Outcoming { get; set; }
        public decimal Balance { get; set; }
        public long AccountTreeId { get; set; }
        public string AccountNameAr { get; set; }
        public string AccountNameEn { get; set; }
        public string Description { get; set; }
    }
}
