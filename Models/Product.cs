﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<DishProduct> DishProducts { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<RequestProduct> ProductRequests { get; set; }
    }
}
