using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Models
{
    public class Equipment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }
    }
}
