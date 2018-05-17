using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Dish
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public double Price { get; set; }

        [ForeignKey("DishId")]
        public virtual List<OrderDish> DishOrders { get; set; }

        [ForeignKey("DishId")]
        public virtual List<DishProduct> DishProducts { get; set; }
    }
}
