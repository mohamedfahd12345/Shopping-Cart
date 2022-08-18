using System;
using System.Collections.Generic;

namespace shopping.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Photo { get; set; }
        public int? Catid { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
