using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class StructureType
    {
        public StructureType()
        {
            Structure = new HashSet<Structure>();
        }

        public int StructureTypeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<Structure> Structure { get; set; }
    }
}
