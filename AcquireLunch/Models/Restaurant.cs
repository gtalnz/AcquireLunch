using System;
using System.Collections.Generic;
using System.Linq;

namespace AcquireLunch.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }

        public virtual List<MenuItem> MenuItems { get; set; }
        public virtual List<RestaurantLocation> RestaurantLocations { get; set; }
    }
}