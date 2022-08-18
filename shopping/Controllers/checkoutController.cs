using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping.Infrastructure;
using shopping.Models;

namespace shopping.Controllers
{
    [Authorize]
    public class checkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order o)
        {
            shoppingContext db = new shoppingContext();
            //1
            var order=new Order();
            order.CustomerAdress = o.CustomerAdress;
            order.CustomerEmail = o.CustomerEmail;
            order.CustomerPhone = o.CustomerPhone;
            order.CustomerName = o.CustomerName;
            order.PaymentType = "Cashe";
            order.Orderdate = DateTime.Now;
            order.Status = "Processing"; 
            db.Orders.Add(order);
            Console.WriteLine(o.Orderid);
            db.SaveChanges();
            List<Order>temp=db.Orders.ToList();
            var t2=temp[temp.Count-1];
            Console.WriteLine(t2.Orderid);
            Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111");
            //2
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart");
            foreach(var c in cart)
            {
                var order1=new Cart();
                order1.Qty = c.Qty;
                order1.Price = c.Price;
                order1.Productid = c.Productid;
                order1.Orderid = t2.Orderid;
                order1.Productnamed = c.Productnamed;
                Console.WriteLine("2222222222222222222222222222222222222222222222222222222222222222222");
                db.Carts.Add(order1);

            }
            //3
            Console.WriteLine("3333333333333333333333333333333333333333333");
            HttpContext.Session.Remove("Cart");
            db.SaveChanges();
            Console.WriteLine("3333333333333333333333333333333333333333333");

            return View("Thanks");
        }
    }
}
