using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ActionTaken
    {
        public ActionTaken()
        {
            Cases = new HashSet<Cases>();
        }

        public int ActionTakenId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
