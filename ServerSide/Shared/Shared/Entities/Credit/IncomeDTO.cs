﻿using Data.Entities.Debit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class IncomeDTO : BaseEntity
    {
        public DateTime Date { get; set; }
        public string CartNumber { get; set; }
        public int CategoryId { get; set; }
        public long FarmId { get; set; }
        public int DriverId { get; set; }
        public decimal Quantity { get; set; }
        public decimal KiloDiscount { get; set; }
        public decimal Total { get; set; }
        public decimal KiloPrice { get; set; }
        public decimal MoneyDiscount { get; set; }
        public decimal Balance { get; set; }
        public long StationId { get; set; }
        public decimal PaidUp { get; set; }
        public DateTime PaidDate { get; set; }
        public string RecieptNumber { get; set; }

        public virtual FarmDTO Farm { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual DriverDTO Driver { get; set; }
        public virtual StationDTO Station { get; set; }


    }
}
