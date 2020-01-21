using System;
using System.Collections.Generic;
using System.Text;

namespace Farms.Models
{
    public class ExportDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long FarmId { get; set; }
        public string CarPlate { get; set; }
        public decimal Weight { get; set; }
        public decimal Pardon { get; set; }
        public decimal WeightAfterPardon { get; set; }
        public decimal Price { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public virtual FarmDTO Farm { get; set; }
    }
}
