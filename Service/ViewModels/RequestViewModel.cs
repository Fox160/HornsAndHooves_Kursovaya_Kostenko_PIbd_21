using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Date { get; set; }

        public List<RequestProductViewModel> RequestProducts { get; set; }
    }
}
