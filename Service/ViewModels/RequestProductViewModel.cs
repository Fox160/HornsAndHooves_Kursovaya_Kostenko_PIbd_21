using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class RequestProductViewModel
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }
        
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int RequestId { get; set; }
    }
}
