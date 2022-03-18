using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string Author { get; set; } = String.Empty ;

        public string Description { get; set; } = String.Empty ;

        public string ImageURL { get; set; } = String.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public bool Featured { get; set; } = false;

        public List<BookVariant> Variants { get; set; } = new List<BookVariant>();

        public bool Visible { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
