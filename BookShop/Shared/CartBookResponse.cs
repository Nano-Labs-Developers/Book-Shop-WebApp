using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared
{
    public class CartBookResponse
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;
        
        public int BookTypeId { get; set; }
        
        public string BookType { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
