using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BL.Model;

namespace Shop.BL.Controller
{
    class ShopContext:DbContext
    {
        public ShopContext() : base("DBConection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
