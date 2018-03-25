using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RequestProduct
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int RequestId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Request Request { get; set; }
    }
}
