using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class SelectorDTO : BaseEntity
    {
        public string HeadName { get; set; }
        public decimal Balance { get; set; }
        public decimal LastTonPrice { get; set; }
        public virtual IEnumerable<SelectorDetailDTO> SelectorDetails { get; set; }
    }
}
