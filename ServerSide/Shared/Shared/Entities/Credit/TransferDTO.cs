using Data.Entities.Debit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class TransferDTO : BaseEntity
    {
        public DateTime Date { get; set; }
        public long DriverId { get; set; }
        public long FarmId { get; set; }
        public long StationId { get; set; }
        public decimal Nawlon { get; set; }
        public decimal Custody { get; set; }
        public decimal? Withdraws { get; set; }
        public decimal? Balance { get; set; }
        public string Notes { get; set; }
        public virtual DriverDTO Driver { get; set; }
        public virtual FarmDTO Farm { get; set; }
        public virtual StationDTO Station { get; set; }
    }
}
