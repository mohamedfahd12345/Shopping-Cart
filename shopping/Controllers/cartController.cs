using Microsoft.AspNetCore.Mvc;
using shopping.Infrastructure;
using shopping.Models;

namespace shopping.Controllers
{
    public class cartController : Controller
    {
        public IActionResult Index()
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
               GrandTotal = (decimal)cart.Sum(x => x.Qty * x.Price)
            };

            return View(cartVM);

           
        }

      


        public async Task<IActionResult> add(int id)
        {

            shoppingContext db = new shoppingContext();

            var product =  db.Products.Where(x => x.Id == id).FirstOrDefault();
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();
            var cartitem = cart.Where(x => x.Productid == id).FirstOrDefault();

          
            
            var new_cart = new Cart();
            if (cartitem == null)
            {
                new_cart.Qty = 1;
                new_cart.Productid = product.Id;
                new_cart.Productnamed = product.Name;
                new_cart.Price = product.Price;
                new_cart.Photo = product.Photo;
                cart.Add(new_cart);
            

            }
            else
            {
                cartitem.Qty++;
            }
            HttpContext.Session.SetJson("Cart", cart);
            // db.SaveChangesAsync();
           // Console.WriteLine("fdkk hhfkjdhf hdk  ufnuenkla kjnd jfkan");
            return RedirectToAction("Index");

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public IActionResult Decrease(int id)
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart");


            var cartitem = cart.Where(x => x.Productid == id).FirstOrDefault();
            if (cartitem.Qty > 1)
            {
                cartitem.Qty--;
            }
            else if (cartitem.Qty == 1)
            {
                cart.Remove(cartitem);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            // db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart");
            Cart item = cart.Where(x => x.Productid == id).FirstOrDefault();

            cart.Remove(item);
            // cart.RemoveAll(x=>x.Productid==id);
            Console.WriteLine("remove11111111111111111111111111111111111111111");
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }



    }
}
