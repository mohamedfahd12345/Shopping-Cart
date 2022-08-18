using System;
using System.Collections.Generic;

namespace shopping.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string? Userid { get; set; }
        public int? Qty { get; set; }
        public int? Productid { get; set; }
        public string? Productnamed { get; set; }
        public string? Photo { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Orderid { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
