using System;
using System.Collections.Generic;

namespace shopping.Models
{
    public partial class Order
    {
        public Order()
        {
            Carts = new HashSet<Cart>();
        }

        public int Orderid { get; set; }
        public DateTime? Orderdate { get; set; }
        public string PaymentType { get; set; } = null!;
        public string? Status { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAdress { get; set; }
        public string? OrderName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
