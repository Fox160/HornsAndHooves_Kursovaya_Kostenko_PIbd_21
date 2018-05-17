using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public double Price { get; set; }

        [DataMember]
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("RequestId")]
        public virtual List<RequestProduct> RequestProducts { get; set; }
    }
}
