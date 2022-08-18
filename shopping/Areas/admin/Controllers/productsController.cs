using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using shopping.Models;
//using shopping.Data;

namespace shopping.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class productsController : Controller
    {
       
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Product Product)
        {
            if (ModelState.IsValid)
            {
                shoppingContext db = new shoppingContext();
                db.Products.Add(Product);
                db.SaveChanges();
                return View();
            }
            return View();
        }

        public IActionResult delete(int id)
        {
            shoppingContext db = new shoppingContext();
            var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
            db.Products.Remove(product);
            var cart = db.Carts.Where(x => x.Productid == id).ToList();
            foreach (var i in cart)
            {
                db.Carts.Remove(i);
            }
            db.SaveChanges();
            // return View("create");
            return Redirect("/admin/Home/categories");
        }

        public IActionResult edit(int id)
        {
            shoppingContext db = new shoppingContext();
            var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine("gvhjfufyuftyftydytdytdtydytdydttuf fyf tftyty vf ftyfgf ty ft  yt ytf tuf ");
            return View(product);
        }
        
        [HttpPost]
        public IActionResult edit(Product P)
        {
            Console.WriteLine("mmomomommomomomomomomomom");
            if (ModelState.IsValid)
            {
                shoppingContext db = new shoppingContext();
                db.Products.Update(P);
                db.SaveChanges();
                Console.WriteLine("C# is coolkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");
                return Redirect("/admin/Home/categories");
                
            }
            return Redirect("/admin/Home/categories");
            
        }


    }
}
