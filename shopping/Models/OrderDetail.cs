using System;
using System.Collections.Generic;

namespace shopping.Models
{
    public partial class OrderDetail
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public string? Productnamed { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
