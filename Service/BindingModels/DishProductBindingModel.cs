using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BindingModels
{
    public class DishProductBindingModel
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int DishId { get; set; }

        public int ProductId { get; set; }
    }
}
