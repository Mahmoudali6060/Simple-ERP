using Data.Entities.Shared;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Debit
{
    public class Safe : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Incoming { get; set; }
        public decimal Outcoming { get; set; }
        public string RecieptNumber { get; set; }
        public AccountTreeEnum AccountTreeType { get; set; }
        public long AccountId { get; set; }
        public string AccountNameAr { get; set; }
        public string Description { get; set; }
    }
}
