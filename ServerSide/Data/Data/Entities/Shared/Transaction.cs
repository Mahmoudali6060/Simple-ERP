using Data.Entities.Credit;
using Data.Entities.Debit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Shared
{
    public class Transaction : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public long FarmId { get; set; }
        public string FarmOwnerName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long DriverId { get; set; }
        public string CarPlate { get; set; }
        public decimal SupplierQuantity { get; set; }
        public decimal Pardon { get; set; }
        public decimal TotalAfterPardon { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal SupplierAmount { get; set; }
        public decimal Nolon { get; set; }
        public long ReaperId { get; set; }
        public string ReaperHead { get; set; }
        public decimal ReapersPay { get; set; }
        public long SelectorId { get; set; }
        public decimal SelectorsPay { get; set; }
        public decimal FarmExpense { get; set; }
        public decimal SupplierTotal { get; set; }
        public long StationId { get; set; }
        public string StationOwnerName { get; set; }
        public string CartNumber { get; set; }
        public decimal ClientQuantity { get; set; }
        public decimal ClientDiscount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public decimal ClientPrice { get; set; }
        public decimal ClientTotal { get; set; }
        public decimal Sum { get; set; }

        public Category Category { get; set; }
        public Farm Farm { get; set; }
        public Driver Driver { get; set; }
        public Reaper Reaper { get; set; }
        public Station Station { get; set; }
    }
}
