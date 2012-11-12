using System;
using System.Collections.Generic;
using System.Linq;

namespace AcquireLunch.Models
{
    public class SingleOrder
    {
        public int SingleOrderId { get; set; }
        public string Notes { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}