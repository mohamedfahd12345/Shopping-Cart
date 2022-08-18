using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping.Models;

namespace shopping.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ordersController : Controller
    {
        public IActionResult Index()
        {
            shoppingContext db = new shoppingContext();
            var orders = db.Orders.ToList(); 
            return View(orders);
        }
        
        public IActionResult Ind(int id)
        {
            if (id == 1)
            {
                shoppingContext db = new shoppingContext();
                var orders = db.Orders.Where(x=>x.Status== "Processing").ToList();
                return View("Index", orders);
            }
            else if(id==2)
            {
                shoppingContext db = new shoppingContext();
                var orders = db.Orders.Where(x => x.Status == "Done").ToList();
                return View("Index",orders);
            }
            else
            {
                shoppingContext db = new shoppingContext();
            var orders = db.Orders.ToList(); 
            return View("Index",orders);
            }
           
        }
        public IActionResult order(int id)
        {
            shoppingContext db = new shoppingContext();
            var o = db.Carts.Where(x => x.Orderid == id).ToList();
            decimal s = 0;
            foreach(var it in o)
            {
                var temp = it.Price * it.Qty;
                s += (decimal)temp;
            }
            o[0].TotalPrice = s;
            return View(o);
        }

        [HttpPost]
        public IActionResult order(List<Cart>o)
        {
            Console.WriteLine("1111111111111111111111111111111");

            Console.WriteLine(o[0].Photo);
            Console.WriteLine(o[0].Orderid);

            shoppingContext db = new shoppingContext();
            var temp=db.Orders.Where(x=>x.Orderid==o[0].Orderid).ToList();  
            foreach(var item in temp)
            {
                item.Status = o[0].Photo;
                db.Orders.Update(item);
                db.SaveChanges();
            }
            return Redirect("/admin/orders/Index");
        }


    }
}
