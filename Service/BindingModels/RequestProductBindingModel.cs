using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BindingModels
{
    public class RequestProductBindingModel
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int RequestId { get; set; }
    }
}
