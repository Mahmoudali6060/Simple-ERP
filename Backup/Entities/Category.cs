using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Outcome> Outcomes { get; set; }
    }
}
