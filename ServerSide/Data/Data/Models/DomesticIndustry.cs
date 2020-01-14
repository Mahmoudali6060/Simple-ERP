using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class DomesticIndustry
    {
        public DomesticIndustry()
        {
            Cases = new HashSet<Cases>();
        }

        public int DomesticIndustryId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
