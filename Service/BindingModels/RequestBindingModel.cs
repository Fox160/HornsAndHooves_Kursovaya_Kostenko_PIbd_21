using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }

        public List<RequestProductBindingModel> RequestProducts { get; set; }
    }
}
