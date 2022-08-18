using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping.Models;

namespace shopping.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult categories()
        {
            shoppingContext db = new shoppingContext();
              var c=  db.Categories.ToList();
            return View(c);
        }

        public IActionResult ALLproduct(int id)
        {
            shoppingContext db = new shoppingContext();
            var product = db.Products.Where(x=>x.Catid==id).ToList();
            return View(product);
        }

        public IActionResult product(int id)
        {
             shoppingContext db = new shoppingContext();
            var p = db.Products.Where(x => x.Id== id).ToList();
            var product = p[0];
            return View(product);
        }

       // [Authorize]
        public IActionResult shoppingbag()
        {
            
            return View();
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}