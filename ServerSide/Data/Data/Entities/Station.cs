using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Station
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OwnerMobile { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<Income> Incomes { get; set; }
    }
}
