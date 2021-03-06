﻿using Data.Entities.Debit;
using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class Income : BaseEntity
    {
        public DateTime Date { get; set; }
        public string CartNumber { get; set; }
        public int CategoryId { get; set; }
        public long FarmId { get; set; }
        public long DriverId { get; set; }
        public decimal Quantity { get; set; }
        public decimal KiloDiscount { get; set; }
        public decimal KiloPrice { get; set; }
        public decimal MoneyDiscount { get; set; }
        public decimal Balance { get; set; }
        public long StationId { get; set; }
        public long TransactionId { get; set; }
        public virtual Farm Farm { get; set; }
        public virtual Category Category { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Station Station { get; set; }


    }
}
