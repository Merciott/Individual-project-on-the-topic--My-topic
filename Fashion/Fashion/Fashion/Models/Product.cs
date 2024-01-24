using System;
using System.Collections.Generic;

namespace Fashion.Models
{
    public partial class Product
    {
        public Product()
        {
            Reviews = new HashSet<Review>();
            Zakazis = new HashSet<Zakazi>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Category { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Zakazi> Zakazis { get; set; }
    }
}
