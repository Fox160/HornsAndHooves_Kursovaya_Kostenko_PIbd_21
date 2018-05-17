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
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public DateTime Date { get; set; }

        [DataMember]
        [Required]
        public bool IsCompleted { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<OrderDish> OrderDishes { get; set; }
    }
}
