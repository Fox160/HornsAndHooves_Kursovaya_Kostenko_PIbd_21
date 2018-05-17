using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class OrderDish
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int DishId { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Order Order { get; set; }
    }
}
