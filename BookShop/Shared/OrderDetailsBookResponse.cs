using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared
{
    public class OrderDetailsBookResponse
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string BookType { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
