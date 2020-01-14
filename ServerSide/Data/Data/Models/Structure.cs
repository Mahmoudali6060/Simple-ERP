using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Structure
    {
        public Structure()
        {
            InverseStructureParent = new HashSet<Structure>();
        }

        public int StructureId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int StructureTypeId { get; set; }
        public int? StructureParentId { get; set; }

        public virtual Structure StructureParent { get; set; }
        public virtual StructureType StructureType { get; set; }
        public virtual Cases Cases { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<Structure> InverseStructureParent { get; set; }
    }
}
