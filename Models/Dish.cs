using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("DishId")]
        public virtual List<OrderDish> DishOrders { get; set; }

        [ForeignKey("DishId")]
        public virtual List<DishProduct> DishProducts { get; set; }
    }
}
