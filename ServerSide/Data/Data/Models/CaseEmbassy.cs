using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CaseEmbassy
    {
        public int CaseEmbassyId { get; set; }
        public int CaseId { get; set; }
        public int EmbassyId { get; set; }

        public virtual Cases Case { get; set; }
        public virtual Embassies Embassy { get; set; }
    }
}
