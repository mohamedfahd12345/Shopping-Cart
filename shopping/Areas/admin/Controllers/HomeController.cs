using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using shopping.Models;

namespace shopping.Areas.admin.Controllers
{
   
    [Area("admin")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult categories()
        {
            shoppingContext db = new shoppingContext();
            var c = db.Categories.ToList();
            return View(c);
        }

        public IActionResult ALLproduct(int id)
        {
            shoppingContext db = new shoppingContext();
            var product = db.Products.Where(x => x.Catid == id).ToList();
            return View(product);
        }

        public IActionResult product(int id)
        {
            shoppingContext db = new shoppingContext();
            var p = db.Products.Where(x => x.Id == id).ToList();
            var product = p[0];
            return View(product);
        }
    }
}
