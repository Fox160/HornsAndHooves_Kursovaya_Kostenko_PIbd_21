using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class RequestProduct
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int RequestId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Request Request { get; set; }
    }
}
