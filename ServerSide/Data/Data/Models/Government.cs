using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Government
    {
        public Government()
        {
            Cases = new HashSet<Cases>();
        }

        public int GovernmentId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
