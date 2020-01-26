using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Income
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Cart { get; set; }
        public int CategoryId { get; set; }
        public long FarmId { get; set; }
        public int DriverId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Pardon { get; set; }
        public decimal Total { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual Category Category { get; set; }
        public virtual Driver Driver { get; set; }

    }
}
