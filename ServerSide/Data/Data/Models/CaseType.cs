using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CaseType
    {
        public CaseType()
        {
            Cases = new HashSet<Cases>();
        }

        public int CaseTypeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
