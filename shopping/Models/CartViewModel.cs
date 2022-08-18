namespace shopping.Models
{
    public class CartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
