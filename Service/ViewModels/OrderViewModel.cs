using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public bool IsCompleted { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public double Price { get; set; }
    }
}
