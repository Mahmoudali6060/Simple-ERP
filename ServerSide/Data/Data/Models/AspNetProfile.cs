using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class AspNetProfile
    {
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
