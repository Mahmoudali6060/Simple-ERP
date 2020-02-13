using Data.Entities.Credit;
using Data.Entities.Debit;
using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class Transfer : BaseEntity
    {
        public DateTime Date { get; set; }
        public long DriverId { get; set; }
        public long FarmId { get; set; }
        public long StationId { get; set; }
        public decimal Nolon { get; set; }
        public decimal Custody { get; set; }
        public decimal? Withdraws { get; set; }
        public decimal? Balance { get; set; }
        public string Notes { get; set; }
        public long TransactionId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Farm Farm { get; set; }
        public virtual Station Station { get; set; }
    }
}
