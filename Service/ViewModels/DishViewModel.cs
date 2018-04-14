using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public virtual List<DishProductViewModel> DishProducts { get; set; }
    }
}
