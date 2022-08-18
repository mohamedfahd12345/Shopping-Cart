using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using shopping.Models;
namespace shopping.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class categoriesController : Controller
    {
        public IActionResult create()
        {
            Console.WriteLine("11111");
            return View();
        }

        [HttpPost]
        public IActionResult create(Category category)
        {
           
            shoppingContext db = new shoppingContext();
            db.Categories.Add(category);
            db.SaveChanges();
           
            return View();
        }
        public IActionResult delete(int id)
        {
            shoppingContext db = new shoppingContext();
            var category=db.Categories.Where(x=>x.Id==id).FirstOrDefault(); 
            db.Categories.Remove(category);
            var products = db.Products.Where(x => x.Catid == id).ToList();
            foreach (var i in products)
            {
                db.Products.Remove(i);
            }
            db.SaveChanges();
            return Redirect("/admin/Home/categories");
        }

        public IActionResult edit(int id)
        {
            shoppingContext db = new shoppingContext();
            var category = db.Categories.Where(x => x.Id == id).FirstOrDefault(); ;
            return View(category);
        }
        [HttpPost]
        public IActionResult edit(Category category)
        {
            if (ModelState.IsValid)
            {
                shoppingContext db = new shoppingContext();
                db.Categories.Update(category);
                db.SaveChanges();
                return Redirect("/admin/Home/categories");

            }
            return Redirect("/admin/Home/categories");
        }
    }
}
