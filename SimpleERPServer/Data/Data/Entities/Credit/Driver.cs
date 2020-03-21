using Data.Entities.Debit;
using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class Driver : BaseEntity
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string CarPlate { get; set; }
        public virtual IEnumerable<Transfer> Transfers { get; set; }
        public virtual IEnumerable<Outcome> Outcomes { get; set; }


    }
}
