using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Embassies
    {
        public Embassies()
        {
            CaseEmbassy = new HashSet<CaseEmbassy>();
        }

        public int EmbassyId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public virtual ICollection<CaseEmbassy> CaseEmbassy { get; set; }
    }
}
