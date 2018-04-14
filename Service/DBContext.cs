using System;
using System.Collections.Generic;
using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DBContext : DbContext
    {
        public DBContext() : base("HH_DBContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Dish> Dishes { get; set; }

        public virtual DbSet<OrderDish> OrderDishs { get; set; }

        public virtual DbSet<DishProduct> DishProducts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<RequestProduct> RequestProducts { get; set; }

        public virtual DbSet<Request> Requests { get; set; }
    }
}
