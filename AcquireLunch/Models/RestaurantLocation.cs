using System;
using System.Collections.Generic;
using System.Linq;

namespace AcquireLunch.Models
{
    public class RestaurantLocation
    {
        public int RestaurantLocationId { get; set; }
        public string LocationName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}