using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Save
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Incoming { get; set; }
        public decimal Outcoming { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
    }
}
