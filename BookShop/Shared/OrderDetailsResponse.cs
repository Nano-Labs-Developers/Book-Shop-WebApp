using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared
{
    public class OrderDetailsResponse
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderDetailsBookResponse> Books { get; set; }
    }
}
