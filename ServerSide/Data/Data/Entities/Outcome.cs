using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Outcome
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long StationId { get; set; }
        public string Cart { get; set; }
        public int CategoryId { get; set; }
        public int DriverId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal Price { get; set; }

        public virtual Station Staion { get; set; }
        public virtual Category Category { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
