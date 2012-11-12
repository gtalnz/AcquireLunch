using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AcquireLunch.Models
{
    public class AcquireLunchDb : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantLocation> RestaurantLocations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<SingleOrder> SingleOrders { get; set; }
    }
}