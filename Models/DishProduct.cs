﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DishProduct
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int DishId { get; set; }

        public int ProductId { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Product Product { get; set; }
    }
}