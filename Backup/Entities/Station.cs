using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Station
    {
        public long Id { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<Outcome> Outcomes { get; set; }
        public virtual IEnumerable<Transfer> Transfers { get; set; }

    }
}
